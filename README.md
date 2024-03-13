# CarBook Projesi

CarBook, araç kiralama işlemlerinin yapıldığı, araçların ücretlerinin bulunduğu ve araçlar hakkında detaylı bilgilerin alınabildiği bir web uygulamasıdır. Bu uygulama, ASP.NET Core 8 kullanılarak geliştirilmiştir. Backend kısmında Onion, CQRS ve Mediator patternleri kullanılarak oluşturulmuş bir Web API bulunmaktadır. Veritabanı olarak MSSQL kullanılmıştır. Ayrıca, kullanıcı ve rol yetkilendirmeleri için Identity yapısı entegre edilmiştir.

## Özellikler

- Araçların eklenmesi, güncellenmesi ve silinmesi
- Araç kiralama işlemleri
- Araçların ücretlerinin belirlenmesi
- Araçlar hakkında detaylı bilgi alınması
- Blog gibi detaylar
- Admin paneli

## Kullanılan Teknolojiler

### Backend
- ASP.NET Core 8: Backend tarafında kullanılan framework.
- Onion, CQRS ve Mediator Patternleri: Proje içindeki iş mantığını organize etmek için kullanılmıştır.
- MSSQL: Veritabanı olarak tercih edilmiştir.
- Identity: Kullanıcı ve rol yetkilendirmeleri için entegre edilmiştir.
- AutoMapper: Objeler arasında veri eşleştirmesi sağlamak için kullanılmıştır.

### Frontend
- MVC (Model-View-Controller): Frontend tarafında kullanılan model-view-controller mimarisi.
- HTML, CSS, JavaScript: Web sitesi için temel teknolojiler.

## Proje Yapısı

Proje, Onion mimarisini takip eder. Temel katmanlar şunlardır:

- **Core:** Temel varlıklar ve iş mantığı kuralları burada bulunur.
- **Infrastructure:** Veritabanı işlemleri ve harici servisler burada bulunur.
- **Application:** Uygulama katmanı, iş mantığını uygular ve dış dünya ile etkileşim kurar.
- **Web API:** RESTful API'yi sağlayan ve istekleri işleyen katmandır.
- **Web UI:** MVC tarafı, kullanıcı arayüzünü oluşturur ve sunar.
- **Admin Panel:** Yönetici arayüzü için ayrı bir bölüm bulunmaktadır.

## Ekran Görüntüleri

### Ana Sayfa ve Diğer Sayfalar

![Sayfa Görüntüsü 1](Screenshots/1.png)
![Sayfa Görüntüsü 2](Screenshots/2.png)
![Sayfa Görüntüsü 3](Screenshots/3.png)
![Sayfa Görüntüsü 4](Screenshots/4.png)
![Sayfa Görüntüsü 5](Screenshots/5.png)
![Sayfa Görüntüsü 6](Screenshots/6.png)
![Sayfa Görüntüsü 7](Screenshots/7.png)


### Admin Paneli

![Admin Paneli Görüntüsü 1](Screenshots/8.png)
![Admin Paneli Görüntüsü 2](Screenshots/9.png)
![Admin Paneli Görüntüsü 3](Screenshots/10.png)
![Admin Paneli Görüntüsü 4](Screenshots/11.png)
![Admin Paneli Görüntüsü 5](Screenshots/12.png)
![Admin Paneli Görüntüsü 6](Screenshots/13.png)
![Admin Paneli Görüntüsü 7](Screenshots/14.png)

### Swagger Ekran Görüntüleri

![Swagger Görüntüsü 1](Screenshots/15.png)
![Swagger Görüntüsü 2](Screenshots/16.png)

## Kurulum

1. Projenin klonlanması: `git clone https://github.com/anilklc/CarBook.git`
2. Visual Studio veya Visual Studio Code ile projenin açılması.
3. `appsettings.json` dosyasında veritabanı bağlantı dizesinin güncellenmesi.
4. Package Manager Console veya Terminal'i açın.
5. Migration'ların alınması ve veritabanının oluşturulması için aşağıdaki komutları sırasıyla çalıştırın:
   ```bash
   dotnet ef migrations add InitialMigration
   dotnet ef database update

6. Projenin derlenmesi ve çalıştırılması.

## Gereksinimler

- .NET Core SDK
- MSSQL Server
