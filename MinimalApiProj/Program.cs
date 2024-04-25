using MinimalApiProj;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

StudentOps.Init();


app.MapGet("/students", () =>
{
    return StudentOps.students;
}).WithName("studentsGet").WithOpenApi();

app.MapGet("/rr", () => Results.Created());

app.MapGet("/student/{id}", (int id) =>
{
    var studentToReturn = StudentOps.GetStudentById(id);
    if (studentToReturn == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(studentToReturn);
}).WithName("studentGet").WithOpenApi();


app.MapPost("students", (Student student) =>
{
    StudentOps.AddStudent(student);
    return Results.Created();
}).WithName("studentAdd").WithOpenApi();

app.MapPut("/student", (Student student) =>
{
    return Results.Ok();
}).WithName("studentPut").WithOpenApi();

app.Run();

