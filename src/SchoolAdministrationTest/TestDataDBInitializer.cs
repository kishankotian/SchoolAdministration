using EntityFramework;
using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdministrationTest
{
    public class TestDataDBInitializer
    {
        public TestDataDBInitializer()
        {

        }

        public void Seed(SchoolDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Teachers.AddRange(
                new Teacher() { Id = "67882670-54BD-4C9E-8F9C-924B76ECB468", Email = "teacher4@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Teacher() { Id = "9C8BFFFD-E9D8-4F48-8CA4-57C3698537D8", Email = "teacher3@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Teacher() { Id = "9E5A7FA0-32EA-4434-9B4A-C035C343AB79", Email = "teacher2@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Teacher() { Id = "C6DDD99E-BD3F-4EB1-8549-DCC2C6419ACA", Email = "teacher1@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" }
            );

            context.Students.AddRange(
                new Student() { Id = "69ac13e0-9d4b-40af-a7ef-29677cc25eb6", Email = "student1@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Student() { Id = "79f80b81-0cc1-4700-9e04-6a0ee549da0f", Email = "student2@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Student() { Id = "807738d3-0c89-4dda-9119-bc169919c3c4", Email = "student3@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Student() { Id = "a2ff4795-03ec-4408-b8d1-100669bf9073", Email = "student4@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Student() { Id = "c75116c8-aa56-4b47-87a8-9da1992b2299", Email = "student5@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Student() { Id = "fe1ca50e-df57-45f6-8c63-66900e5c6a41", Email = "student6@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" }
            );
            context.Registrations.AddRange(
                new Registration() { Id = "119a9a53-a081-4416-a5e1-3173b048d535", StudentEmail = "student1@gmail.com", RegisteredBy = "teacher1@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "1db8e79f-072e-4a1c-bba2-9708b1969221", StudentEmail = "student2@gmail.com", RegisteredBy = "teacher1@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "30ad037e-0fcd-413d-bd4b-e74feb718a0b", StudentEmail = "student3@gmail.com", RegisteredBy = "teacher1@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "31024268-b4af-4dc2-a0d7-96e9a5793a6a", StudentEmail = "student2@gmail.com", RegisteredBy = "teacher2@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "384ecfe4-e413-47c2-9b69-9f43043e4645", StudentEmail = "student4@gmail.com", RegisteredBy = "teacher2@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "3918ae85-e86d-422a-a6eb-48b4a54e66a2", StudentEmail = "student5@gmail.com", RegisteredBy = "teacher3@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "59a2d350-cb5b-40c6-bf00-ebcdded3a2df", StudentEmail = "student6@gmail.com", RegisteredBy = "teacher3@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "777a7c86-18d5-425c-8271-1d319fe214b2", StudentEmail = "student3@gmail.com", RegisteredBy = "teacher3@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" },
                new Registration() { Id = "86e79b18-6b6c-4389-9615-eb1faf8baa3a", StudentEmail = "student6@gmail.com", RegisteredBy = "teacher4@gmail.com", IsActive = true, Created = DateTime.Now, CreatedBy = "seed" }
             );
            context.SaveChanges();
        }
    }   
}
