**Emlak Sitesi Projesi**

Bu proje, kurumsal mimari prensiplerini kullanarak geliştirilen bir Emlak Sitesi uygulamasıdır. Proje, ASP.NET Core 6.0 kullanılarak geliştirilmiş olup, CRUD işlemleri, JWT ile yetkilendirme, admin ve kullanıcı panelleri, API entegrasyonu gibi birçok önemli teknoloji ve yaklaşımı kapsamaktadır. Projenin amacı, Asp.Net Core ve kurumsal mimarileri öğrenmek ve uygulamak isteyen geliştiriciler için kapsamlı bir rehber sunmaktır.

Proje Özeti:

- 3 farklı panel (Admin, Kullanıcı, Site Arayüzü) ile çok kullanıcılı bir sistem geliştirildi.
- CRUD (Create, Read, Update, Delete) işlemleri detaylı olarak anlatıldı.
- Repository Design Pattern ile daha sade ve temiz kodlar yazıldı.
- JWT tabanlı kimlik doğrulama ve yetkilendirme işlemleri yapıldı.
- Postman ve Swagger kullanarak API testi gerçekleştirildi.
- Google ile giriş, şifre sıfırlama, reCAPTCHA doğrulaması gibi özellikler eklendi.
- HttpClient ile arka planda JWT gönderimi sağlandı.
- Fluent Validation ile veri doğrulama işlemleri gerçekleştirildi.
- SweetAlert, Toastr ile kullanıcıya mesajlar gösterildi.
- jQuery ve Vue.js gibi kütüphaneler kullanılarak dinamik işlemler yapıldı.
- Kullanılan Teknolojiler
- .NET Core 6.0
- ASP.NET Core MVC
- Entity Framework Core (ORM)
- Repository Design Pattern
- JWT (JSON Web Token) ile yetkilendirme
- Web API (RESTful)
- HttpClient ile API talepleri
- Fluent Validation ile form doğrulama
- Postman ve Swagger ile API testi
- jQuery ve Vue.js (Frontend geliştirme)
- SweetAlert ve Toastr (Mesaj ve bildirim)
- Google OAuth ile giriş
- reCAPTCHA doğrulaması
- Mail gönderimi (Şifre sıfırlama) // Kod detayı yok fakat önizleme yapıldı
- Docker (Opsiyonel: Proje konteynerizasyonu)
  
**Proje Yapısı**
  
Proje, katmanlı mimari prensiplerine göre yapılandırılmıştır ve aşağıdaki gibi temel katmanlara ayrılmıştır:

-> WebUI: Kullanıcı arayüzü (Admin, Kullanıcı ve Genel Site Panelleri)
-> API: RESTful servisler
-> Application: İş mantığı katmanı
-> Domain: Temel modeller ve iş kuralları
-> Infrastructure: Veri erişim ve üçüncü parti entegrasyonlar

**Öne Çıkan Özellikler**

- Dinamik Filtreleme: İlanlar üzerinde anlık filtreleme işlemleri.
- Cascading Dropdown: İlişkili dropdown listeleri.
- Admin Paneli: İlan yönetimi, kullanıcı yönetimi ve istatistikler.
- Kullanıcı Paneli: Kullanıcıların ilanlarını yönetebildiği kontrol paneli.
- JWT Authentication: JWT token ile güvenli API erişimi.
- Google Giriş: Google OAuth entegrasyonu ile hızlı kullanıcı girişi.
- Şifre Sıfırlama: E-posta ile şifre sıfırlama işlemleri.
- API Entegrasyonu: Web uygulamasında API kullanımı ve JWT ile güvenlik.
- Validasyon: FluentValidation ile form doğrulama.
- Mesajlar: SweetAlert ve Toastr ile kullanıcı bildirimleri.

Projede emeği geçen "Siber Güvenlik Akademisi" Youtube kanalına teşekkürler.
