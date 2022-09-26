
# phonebook

## Proje Ayarları Hakkında
- Ben RabbitMQ ve PostgreSQL'i docker üzerinden kullandım. Proje içerisindeki **docker-compose.yml** docker'da up edilirse, bağlantıda bir sorun yaşanmayacaktır.
- PostgreSQL'in connection string'leri: 

		PhoneBook.Data > Context > PhoneBookDbContext
		PhoneBook.Report.Data > Context > PhoneBookReportDbContext

 - Connection string'ler düzenlendikten sonra, veritabanları migrate edilebilir.
 - PhoneBook.WebApi **http://localhost:5001** adresinden, PhoneBook.Report.WebApi **http://localhost:5002** adresinden yayınlanmaktadır. PhoneBook.WebApi url'inde bir değişiklik yapıldığında, yeni url aşağıda yolu verilmiş olan sınıfta da düzenlenmelidir.

		 PhoneBook.Report.Creator > Providers > ServiceEndPoints
- RabbitMQ ile ilgili ayarlar aşağıdaki dosyadan yapılabilir
	
		PhoneBook.Report.Business > RabbitMQ
- Excel dökümanı **C:\PhoneBookReports\LocationReports**  dizinine oluşmaktadır. Aşağıda verilmiş olan sınıftan, path değiştirilebilir.

		PhoneBook.Report.Creator > Common> FileWriterPath


