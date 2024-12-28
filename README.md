# Berber Randevu ve Yapay Zeka Destekli Yönetim Sistemi

## Proje Tanımı
Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir berber randevu ve yönetim sistemidir. Proje, kullanıcıların kolayca randevu oluşturmasını sağlarken, yapay zeka desteğiyle kullanıcıların kendilerini farklı saç ve sakal modelleriyle görmelerine olanak tanır. Aynı zamanda, admin paneli üzerinden hizmetler, personeller ve randevuların yönetimi sağlanır.

## Özellikler
### 1. **Ana Sayfa ve Randevu Formu**
Ana sayfa üzerinde bir randevu formu bulunur. Kullanıcı, bu formu doldurarak randevu talebinde bulunabilir. Form şu adımları içerir:
- Kullanıcı adı ve telefon numarası girişi.
- Hizmet seçimi (örneğin: saç kesimi, saç boyama, sakal tıraşı).
- Hizmete uygun personel listesi görüntülenir.
- Tarih ve saat seçimi yapılır (Tarih seçimi lokal zamandan en fazla 1 hafta sonrasına kadar yapılabilir ve saatler yalnızca saat başı seçilebilir).
- Model validasyonu sonrasında randevu "Bekleyen Randevular" listesine eklenir.

### 2. **Yapay Zeka Sayfası**
Kullanıcı, yapay zeka sayfasına girerek fotoğrafını yükler. Sistem, kullanıcıyı 5 farklı saç ve sakal modeline göre analiz eder ve sonuçları görsel olarak sunar. Bu özellik, kullanıcılara tercih yapma konusunda yardımcı olur.

### 3. **Giriş ve Kullanıcı İşlemleri**
- Kullanıcı giriş yaparak kendi bilgilerini görüntüleyebilir ve düzenleyebilir.
- Kullanıcı giriş yapmamışsa, sadece randevu talebinde bulunabilir.

### 4. **Admin Paneli**
Admin giriş yaptığında, sistem yönetim özelliklerine erişim sağlar. Admin paneli şu işlemleri içerir:
- **Randevuları Yönetme**: Bekleyen randevuları onaylama veya iptal etme.
- **Personelleri Yönetme**: Personel ekleme, çıkarma ve güncelleme.
- **Hizmetleri Yönetme**: Hizmet ekleme, çıkarma ve güncelleme.

## Proje Kurulumu
1. Projeyi [GitHub reposundan](#) klonlayın:
   ```bash
   git clone <repository-url>
   ```
2. Projeyi bir .NET geliştirme ortamında açın (örneğin Visual Studio).
3. `appsettings.json` dosyasındaki veritabanı bağlantı ayarlarını yapılandırın.
4. Migration işlemini çalıştırarak veritabanını oluşturun:
   ```bash
   dotnet ef database update
   ```
5. Projeyi başlatın:
   ```bash
   dotnet run
   ```
