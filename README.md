<h2 align="center">
:fire: CQRS Pattern MediatR Kütüphanesi İle Nasıl Uygulanır ? :fire: 
</h2>
  
## :pushpin: CQRS Pattern Nedir ?
CQRS, Command Query Responsibility Segregation‘ın kısaltılmış halidir. 'Command' ve 'Query' sorumluluklarının ayrılması prensibini esas alan bir yaklaşımı savunmaktadır.

Biliyoruz ki, bir uygulama üzerinde kullanıcıdan gelen istekler iki türlüdür. Gelen istek(Request), ya mevcuttaki bir veri üzerinde manipülasyon yapar veya olmayan bir veriyi oluşturur ya da mevcut veri üzerinde herhangi bir işlem yapmaksızın direkt okunmasını sağlar. Yani gelen istek ya bir salt okuma işlemi yapar ya da diğer işlemleri yapar. İşte bu işlemlerden read işlemi yapacak olan isteklere Query, diğerlerine Command denmektedir.

* <b> Command </b> Olmayan veriyi oluşturan ya da var olan bir veri üzerinde güncelleme veya silme işlemi yapan isteklerdir. Örn: INSERT UPDATE DELETE

* <b> Query </b> Mevcut verileri sadece listelemek, okumak yahut sunmak için read işlemi yapan isteklerdir. Örn: SELECT

CQRS, uygulamalarımızda bu istekleri karşılayacak olan yapılanmaları birbirinden ayırmamızı önermektedir.

***

## :pushpin: CQRS Pattern Uygulaması 
CQRS, verileri eklemek, silmek ve güncellemek için 'Command' sınıflarını, okumak için ise 'Query' sınıflarını kullanmaktadır. 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161341-088449ed-3799-448b-a30f-3d2de9d10d7c.png"> </br>
<em>https://sefikcankanber.medium.com/cqrs-command-query-responsibility-segregation-nedir-16b196376389</em>
 </p>
 
İlk olarak bir uygulama oluşturuyoruz yada var olan bir uygulamamız oldugunu varsayıyoruz. İçerisinde 'CQRS' isminde bir klasör oluşturup ardından içerisine 'Commands', 'Queries' ve 'Handlers' isimlerinde klasörler oluşturalım. Ardından tüm klasörlerin içerisine yukarıda görseldeki gibi gelecek olan request’leri ve cevap olarak döndürülecek olan response’ları tanımlayacağımız 'Request' ve 'Response' klasörlerini oluşturalım. 

# Commands
Uygulamada yapılacak olan tüm Command'ları tarif edecek sınıfları barındırmaktadır.

+ Request: Yapılacak Command isteklerini karşılayacak olan sınıfları barındırmaktadır.
+ Response: Yapılan Command isteklerine karşılık verilecek olan response sınıflarını barındırmaktadır.

# Queries
Uygulamada yapılacak olan tüm Query'leri tarif edecek sınıfları barındırmaktadır.

+ Request: Yapılacak Query isteklerini karşılayacak olan sınıfları barındırmaktadır.
+ Response: Yapılan Query isteklerine karşılık verilecek olan response sınıflarını barındırmaktadır.

# Handlers
Uygulamada yapılacak olan tüm Command ya da Query isteklerini işleyecek ve sonuç olarak respose nesnelerini dönecek olan sınıfları barındırmaktadır.

+ CommandHandlers: Yapılan Command isteklerini işler ve response'larını döner.
+ QueryHandlers: Yapılan Query isteklerini işler ve response'larını döner.

Şimdi Command ve Query sınıflarını oluşturalım.

- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Commands`

* CreateProductCommandRequest ve CreateProductCommandResponse class'larımız "Product" ekleme isteklerinde kullanalım.
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161526-39033ead-0bcd-45b4-b925-9dae627e2337.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159161550-91593b26-4de5-4019-a5f4-4e0a3c245716.png"> </br>
 </p>
 
* DeleteProductCommandRequest ve DeleteProductCommandResponse class'larımız "Product" silme isteklerinde kullanalım.
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161593-7d199bd2-f51e-4962-bb16-647296331062.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159161597-7b5ea82d-d648-430d-b5fb-94dbf5e3252c.png"> </br>
 </p>
 
- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Queries`

* GetAllProductQueryRequest ve GetAllProductQueryResponse class'larımız tüm "product" verileri elde edilmek istendiğinde kullanalım.
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161693-9e78e524-aae7-41c0-adc7-1ffc94d78aa0.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159161695-a261fbe8-863b-4ea2-8102-bdbcbd819a8e.png"> </br>
 </p>
 
* GetByIdProductQueryRequest ve GetByIdProductQueryResponse class'larımız id bazlı product sorgulamalarında kullanalım.
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161699-9b4ea6a6-7406-4623-8976-9441da18c0ee.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159161702-509e6d15-32cc-4dcd-bb97-4575c69277d1.png"> </br>
 </p>
  
- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Handlers`

* CreateProductCommandHandler:  Gelen create product isteğinde aşağıdaki 'CreateProductCommandHandler' sınıfı devreye girecek ve 'CreateProduct' isimli metodu üzerinden aldığı 'CreateProductCommandRequest' nesnesindeki değerleri gerçek 'Product' nesnesine dönüştürerek create işlemini gerçekleştirecek ve ardından geriye 'CreateProductCommandResponse' dönerek kullanıcıyı bilgilendirecektir.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161781-7e190cff-ceeb-4e10-8815-6957e7ecffec.png"> </br>
</p>
 
* DeleteProductCommandHandler: Gelen delete product isteğinde aşağıdaki 'DeleteProductCommandHandler' sınıfı devreye girecek ve 'DeleteProduct' isimli metodu üzerinden aldığı 'DeleteProductCommandRequest' nesnesindeki 'Id' değerine karşılık 'Product' nesnesini elde ederek kaynaktan silecek ve ardından geriye 'DeleteProductCommandResponse' dönerek kullanıcıyı bilgilendirecektir. 
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161783-e3e29126-f301-4f78-a2fa-e3847410afe6.png"> </br>
</p>
 
* GetAllProductQueryHandler: Gelen product listesi isteğinde aşağıdaki 'GetAllProductQueryHandler' sınıfı devreye girecek ve 'GetAllProduct' isimli metodu üzerinden tüm 'Product'ları çekecek ve 'List<GetAllProductQueryResponse>' nesnesine dönüştürüp kullanıcıya döndürecektir. Burada 'GetAllProductQueryRequest' nesnesi request olarak gelecektir fakat herhangi bir şarta vs. bağlı bir operasyon gerçekleştirilmeyeceği için içi boş olarak tasarlandığından dolayı herhangi bir işlevsellik göstermemektedir.
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161882-3551d386-4fd6-48c1-812b-525517e2bbbe.png"> </br>
</p>
 
* GetByIdProductQueryHandler: Id bazlı product isteğinde ise aşağıdaki 'GetByIdProductQueryHandler' sınıfı devreye girecek ve 'GetByIdProduct' isimli metodu üzerinden gelen 'GetByIdProductQueryRequest' nesnesindeki 'Id' değerine karşılık 'Product' nesnesi ayıklanıp, 'GetByIdProductQueryResponse' nesnesine dönüştürülüp geriye gönderilecektir.
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161914-df8fa0ec-3f1d-40cd-83ea-ac6d8c8b9ed5.png"> </br>
</p>
 
 İşte CQRS tasarımı bu şekilde ve bundan ibarettir. Artık kullanımına geçelim.
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159161999-e87a23d0-4fc0-478e-b8d3-f6e8c3f42df7.png"> </br>
</p>
 
 + Benim uygulamam Asp.NET Core uygulaması üzerinden örneklendirme olduğu için ilgili Handler sınıflarını uygulamama servis olarak ekliyorum.
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162086-fe1c1f42-76c3-4dcc-9275-82cd743acf10.png"> </br>
</p>

Daha sonra 'ProductsController' isminde bir controller oluşturup içerisinde aşağıdaki gibi endpointlerimi dolduruyorum.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162141-f451a4e9-b567-4a20-b669-928ddb50235a.png"> </br>
</p>

Uygulamamı ayağa kaldırıp ve test ediyorum.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162174-3ce6a8a3-a8aa-4a2f-a997-cabc8d35b999.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159162176-39473c5c-cf12-48cc-bdc8-b2702a4b9915.png"> </br>
</p>
 
Gördüğünüz üzere CQRS pattern'i bu şekilde manuel olarak tasarlarsak eğer ister istemez hem çok zahmetli bir inşa sürecinde bulunmamız gerekecek hem de controller sınıfında haddinden fazla inject işlemi yapmamız gerekecektir. Nihayetinde hangi Response sınıfının hangi Request sınıfına ait olduğunu ve hangi Handler tarafından işleneceğini irademizle takip etmek mecburiyetindeyiz. 

İşte buradaki çoğul model yönetimini daha dinamik bir şekilde sağlayabilmek için Mediator pattern'inden faydalanabiliriz.
 
## :pushpin: Mediator Pattern Nedir ?

Mediator design patternini birbirleriyle ilişkili eş görevli bir grup nesneyi tek merkezden yönetmek ve aralarında gevşek bağlı(loosely coupled) sistemler kurmak istediğimiz durumlarda kullanırız. Mediator patterninden faydalanmak için MediatR Kütüphanesini kullanabiliriz. 

Öncelikle uygulamama MediatR Kütüphanesi eşliğinde Asp.NET Core projesi olmasından dolayı dependency injection paketi olan MediatR.Extensions.Microsoft.DependencyInjection kütüphanelerinide yüklemeyi unutmuyorum.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162412-f47ed936-02e7-4afc-ae38-a69e4ea010cf.png"> </br>
</p>

Daha sonra Asp.NET Core uygulamama aşağıdaki gibi MediatR servisini ekliyorum.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162413-abe0c7f9-2152-486c-8fc0-b70cc159f227.png"> </br>
 </p>

+ IRequest, command veya query requestlerini karşılayacak olan sınıflar tarafından implemente edilecek olan bir arayüzdür. 
 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162914-25dd2dca-6d1b-4ce3-9dee-9bdd047e3baf.png"> </br>
<em>http://www.kamilgrzybek.com/tag/mediatr/</em>
</p>

+ IRequestHandler, command veya query requestlerinin işlenmesini sağlayacak olan Handler sınıflarının arayüzüdür. Generic olarak request ve response sınıflarının bildirilmesini ve ilgili sınıfa içerisindeki 'Handle' isimli methodu implemente etmemizi ister.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162926-802a04b2-4193-4926-85b3-12434db9929c.png"> </br>
<em>http://www.kamilgrzybek.com/tag/mediatr/</em>
</p>
 
***

- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Commands`

* CreateProductCommandRequest ve CreateProductCommandResponse class'larımız 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162414-4dd3eca1-d71f-41e2-ac0a-b92f2cc149ab.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159171179-352fcd5e-2d10-488b-bfb6-5f9f8189c3ae.png"> </br>
 </p>
 
 ***
 
* DeleteProductCommandRequest ve DeleteProductCommandResponse class'larımız 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162416-9161684e-e6e9-4198-b631-f3db9b87352c.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159162417-3db68b25-e6c6-4f12-9b9a-15a9e43d3eeb.png"> </br>
 </p>
 
 ***
 
- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Queries`

* GetAllProductQueryRequest ve GetAllProductQueryResponse class'larımız 

<p align="center">**
<img src="https://user-images.githubusercontent.com/50150182/159162417-3db68b25-e6c6-4f12-9b9a-15a9e43d3eeb.png"> </br>**
<img src="https://user-images.githubusercontent.com/50150182/159162423-40268bb9-fe93-4680-b53b-a13f8962e9de.png"> </br>
 </p>
 
 ***
 
* GetByIdProductQueryRequest ve GetByIdProductQueryResponse class'larımız 
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162424-07415653-d066-4694-bd9b-d0ae481252c6.png"> </br>
<img src="https://user-images.githubusercontent.com/50150182/159162425-865a7d02-1eec-45eb-b2f9-1fa189b4f2b3.png"> </br>
 </p>
 
***

- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `Handlers`

* CreateProductCommandHandler class'ımız 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162426-b1a2f1da-6b29-4522-9455-4566efb4b996.png"> </br>
 </p>
 
 ***
 
 * DeleteProductCommandHandler class'ımız 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162427-df33c0c4-0ae9-44d9-902b-550e58e79a7c.png"> </br>
</p>

***

* GetAllProductQueryHandler class'ımız 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162428-f866c2b6-fdc0-4e1f-a106-669fd0394e80.png"> </br>
</p>

***

* GetByIdProductQueryHandler class'ımız 

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159162429-5018db66-7034-475e-b32d-afcce4fbac53.png"> </br>
</p>
 
MediatR kütüphanesinin en can alıcı noktasıda bu command ve query sınıflarını controller üzerinde kullanırken oldukça kolay ve sade bir implementasyon gerektirmesidir.
Örneği aşağıdaki görselde 😊

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/159171323-3ec7c414-f7c1-4ce7-942f-a29e4df871b0.png"> </br>
</p>

***
