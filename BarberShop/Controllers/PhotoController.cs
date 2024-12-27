using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BarberShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private readonly HttpClient _httpClient;

        public PhotoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Token sunumda yazılacak");
        }

        [HttpGet("process")]
        public IActionResult ProcessPhoto()
        {
            return View();
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPhoto([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Fotoğraf yüklenemedi.");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileUrl = await UploadToCloudinary(memoryStream.ToArray());
            if (fileUrl == null)
            {
                return BadRequest("Fotoğraf yükleme hatası.");
            }

            // Beş sonuç için liste oluştur
            var imageUrls = new List<string>();

            // Prompt seçenekleri
            var prompts = new List<string>
            {
                "Generate Curly hairstyles and Full Beard styles",
                "Create Straight hairstyle with a Goatee beard",
                "Design a professional hairstyle and beard combo",
                "Generate Spiky hairstyles with Moustache beard styles",
                "Create a trendy hairstyle with a groomed beard"
            };

            for (int i = 0; i < 5; i++)  // Beş sonuç almak için
            {
                var randomPrompt = prompts[i];  // Dinamik olarak seçilen prompt

                // Replicate API'ye gönderilecek JSON verisi
                var requestBody = new
                {
                    input = new
                    {
                        image = fileUrl,
                        guidance = 3.5,
                        prompt = randomPrompt  // Dinamik olarak değişen prompt
                    }
                };

                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.PostAsync("https://api.replicate.com/v1/models/black-forest-labs/flux-dev/predictions", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, errorResponse);
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var statusJson = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
                var predictionId = statusJson.GetProperty("id").GetString();

                // Durum kontrolü yaparak bekleme
                var isComplete = false;
                var attempts = 0;

                while (!isComplete && attempts < 10) // 10 kez dene
                {
                    await Task.Delay(5000);  // 5 saniye bekle
                    var getResponse = await _httpClient.GetAsync($"https://api.replicate.com/v1/predictions/{predictionId}");
                    var getJsonResponse = await getResponse.Content.ReadAsStringAsync();
                    var getStatusJson = JsonSerializer.Deserialize<JsonElement>(getJsonResponse);

                    // Durum kontrolü
                    var status = getStatusJson.GetProperty("status").GetString();
                    if (status == "succeeded")  // İşlem başarılıysa
                    {
                        if (getStatusJson.TryGetProperty("output", out var output) && output.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var result in output.EnumerateArray())  // Eğer birden fazla çıktı varsa, her birini ekliyoruz
                            {
                                var resultUrl = result.GetString();
                                imageUrls.Add(resultUrl);
                            }
                        }
                        isComplete = true;
                    }
                    else if (status == "failed")  // Eğer işlem başarısız olduysa
                    {
                        var errorDetails = getStatusJson.GetProperty("error").GetString();
                        return BadRequest($"API işlemi başarısız oldu: {errorDetails}");
                    }
                    else if (status == "queued" || status == "processing")  // İşlem hala devam ediyorsa
                    {
                        // Durum güncel, beklemeye devam et
                    }
                    else
                    {
                        return BadRequest($"Bilinmeyen durum: {status}");
                    }

                    attempts++;
                }

                if (!isComplete)
                {
                    return BadRequest("API işlem tamamlanamadı.");
                }
            }



            ViewData["ImageUrls"] = imageUrls;

            return View();
        }






private async Task<string> UploadToCloudinary(byte[] fileBytes)
    {
        var cloudinary = new Cloudinary(new Account(
            "duwxbff4v",  // Cloudinary'de oluşturduğunuz cloud_name
            "965774791863843",     // API Key
            "eY3jJAatBqEHkn224W-0p5jfTuY"   // API Secret
        ));

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription("uploaded_image.jpg", new MemoryStream(fileBytes))
        };

        try
        {
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            return uploadResult?.SecureUri?.ToString();  // Geçerli dosya URL'si
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading image: {ex.Message}");
            return null;
        }
    }


}
}
