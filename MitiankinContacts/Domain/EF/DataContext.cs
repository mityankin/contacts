namespace MitiankinContacts.Domain.EF
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        // Контекст настроен для использования строки подключения "DataContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Contacts.Domain.EF.DataContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DataContext" 
        // в файле конфигурации приложения.
        public DataContext() : base("name=DataContext")
        {
        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Person>()
//               .HasMany(x => x.PhoneNumbers)
//                .WithOptional()
//                .HasForeignKey(g => g.Id);
//        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Person> ContactPerson { get; set; }
        public virtual DbSet<Phone> ContactPhone { get; set; }
        public virtual DbSet<PhoneType> ContactPhoneType { get; set; }
    }
}