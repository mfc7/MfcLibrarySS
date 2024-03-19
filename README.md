# MfcLibrary Web Uygulaması

MfcLibrary, basit bir kütüphane web uygulamasıdır. Bu uygulama, kitapların eklenmesi, listelenmesi ve ödünç verilmesi gibi temel kütüphane işlemlerini yönetmek için tasarlanmıştır.

## Özellikler

- Kitap listeleme ve ekleme
- Kitap ödünç verme
- Basit kullanıcı arayüzü

## Başlangıç

Uygulamayı çalıştırmak için aşağıdaki adımları izleyin:

1. **Projeyi İndirme:** Projeyi GitHub'dan veya klonladığınız kaynak kod deposundan indirin.
2. **Gerekli Araçları Kurma:** Uygulamanın çalışması için .NET Core SDK ve Visual Studio veya Visual Studio Code gibi bir IDE kurulu olmalıdır.
3. **Veritabanı Bağlantısı:** Veritabanı bağlantısı için uygun bir SQL Server veritabanı oluşturun veya mevcut bir veritabanını kullanın. MfcLibrary.Core'daki **scriptOfLibrary** dosyasını çalıştırın.
4. **Uygulama Ayarları:** `appsettings.json` dosyasında veritabanı bağlantı dizesini güncelleyin. **myConnectionToSql**
5. **Uygulamayı Çalıştırma:** IDE'nizde veya terminalde projeyi açın ve uygulamayı çalıştırın.

## Teknolojiler

- ASP.NET Core MVC
- MSSQL Server
- Dapper
- FluentValidation
- Serilog
- HTML/CSS
- Bootstrap
- JavaScript/jQuery


### Proje Hakkında

- Database'de silme işlemleri için IsActive kolonu eklendi. Aktif olarak kullanıldığında sorguya eklenerek silinen kitaplar önyüzde gösterilmeyebilir.
- Asenkron bir yapı sağlandı.
- Instance alınırken anonim tipler kullanıldı. Dynamic parameters da kullanılabilirdi fakat bunun daha sağlıklı olacağını düşündüm.
- Service tarafında Dto'lar ile; Data access layer'da ise entityler ile çalışıldı.
- Fluent Validation kullanıldı ve örnek validasyonlar eklendi. İsterlere göre detaylandırılabilir.
- AutoMapper kullanıma hazır şekilde projeye eklendi. Örnek kullanım şekli yorum satırında bulunmakta.
- Entity Framework'e veya farklı bir ORM aracına geçiş kolaylığı sağlayacak bir altyapı oluşturuldu.
- Sorgular üzerinden ilerleyerek kitap listesi ve ödünç alan kişilerin sıralanması sağlandı. Kitapların sıralanması ve son ödünç alan kişinin gelmesi, sorgu üzerinden sağlandı.
- "Ödünç Ver" butonu halihazırda dışarıda olan kitaplar için kullanım dışına çıkartılmak istenirse isLoaned durumuna koşul eklenmesi yeterlidir. Yorum satırında bulunmaktadır.
- Serilog örnek kullanımı gösterildi ve kitap ekleme, ödünç verme durumlarında çalışır hale getirildi. Database yerine txt dosyasında loglandı fakat database'e hızlıca adapte olabilecek bir yapı kuruldu.
- UI tarafında Bootstrap kullanılarak responsive bir yapı oluşturuldu.
- Tempdata ve ViewBag kullanılarak frontend uyarıları eklendi.

### Efor Tahmini

| İşlev          | Beklenen Efor (saat) | Gerçekleşen Efor (saat) |
|----------------|-------------------------------|-----------------------------------|
| Database       | 1                             | 1                                 |
| Infrastructure | 3                             | 2                                 |
| Dapper         | 3                             | 5                                 |
| Get Books      | 1                             | 0.5                               |
| Add Book       | 1                             | 1                                 |
| Book Lending   | 1                             | 1                                 |
| Validations    | 1                             | 2                                 |
| Serilog        | 1                             | 1                                 |
| UI & Bootstrap| 1                             | 3                                 |
| Views & Scripts| 2                             | 4                                 |

Not: Toplamda 2 insan/gün olarak eforlamıştım fakat frontend tarafındaki eksiklerim ve öğrenim sürecinden dolayı 3 günde tamamladım.

### 15-18 / 03 / 2024
### Fatih ÇATAL
