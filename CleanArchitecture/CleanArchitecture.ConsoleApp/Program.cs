using CleanArchitecture.Data.Common;
using CleanArchitecture.Domain.Entities;

MainContext mainContext = new();


// Crear los primeros registros

Company company = new Company()
{
    Id = Guid.NewGuid(),
    Name = "Compañía de Prueba",
    Code = "000" ,
    CreatedDateTime = DateTime.UtcNow,
    UpdatedDateTime = DateTime.UtcNow,
    State = true
};

mainContext!.Companies!.Add(company);
await mainContext!.SaveChangesAsync();



List<Company> companies = new List<Company>();

companies = mainContext!.Companies!.ToList();

foreach (var item in companies)
{
    Console.WriteLine($"{item.Id} - {item.Name}");
}
