Bu .NET 6 uygulaması, RabbitMQ mesaj kuyruğu aracılığıyla iletişim kuran iki konsol uygulamasından oluşmaktadır: biri üretici (Producer), diğeri tüketici (Consumer) rolünü üstlenir.

Teknolojiler ve Kütüphaneler:

.NET 6: Uygulamanın temeli .NET 6 sürümü üzerine inşa edilmiştir.
RabbitMQ.Client: RabbitMQ ile etkileşim için kullanılan resmi RabbitMQ istemcisidir.
System.Text.Json: JSON serileştirmesi için kullanılan .NET kütüphanesidir.
Uygulamalar:

Producer (Üretici):

Üretici uygulaması, kullanıcıdan alınan metin girdilerini JSON formatına dönüştürerek RabbitMQ mesaj kuyruğuna gönderir.
Kullanıcı "exit" komutunu girene kadar tekrar tekrar metin girişi yapabilir.
Consumer (Tüketici):

Tüketici uygulaması, RabbitMQ mesaj kuyruğundan gelen JSON formatındaki mesajları alır ve ekrana yazdırır.
Uygulama sürekli olarak kuyruğu dinler ve yeni mesajlar geldikçe ekrana yazdırır.
