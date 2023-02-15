// Opret builder-objektet, der bruges til at konfigurere og oprette webapplikationen
var builder = WebApplication.CreateBuilder(args);

// Tilføj controllers til webapplikationens servicecontainer. Kontrollere håndterer HTTP-anmodninger og sender svar tilbage til klienten.
builder.Services.AddControllers();

// Tilføj en API Explorer, som genererer en konsol, der indeholder detaljerede oplysninger om API'et.
builder.Services.AddEndpointsApiExplorer();

// Tilføj Swagger-klassebiblioteket, der bruges til at oprette et dokument til beskrivelse af API'et.
builder.Services.AddSwaggerGen();

// Opret en instans af webapplikationen ved at kalde Build() på builder-objektet.
var app = builder.Build();

// Konfigurer HTTP-anmodningspipelinen.
if (app.Environment.IsDevelopment())
{
    // Tilføj Swagger og Swagger UI til pipeline, hvis applikationen kører i udviklingstilstand.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Omdiriger HTTP-anmodninger til HTTPS
app.UseHttpsRedirection();

// Tilføj autorisation til HTTP-anmodningspipelinen.
app.UseAuthorization();

// Map kontrollerklasserne til HTTP-anmodningspipelinen.
app.MapControllers();

// Kør webapplikationen
app.Run();

