var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.MapGet("/version", () =>
{
    var info = GitVersionInformation.FullBuildMetaData;
    var ginfo = GitVersionInformation.InformationalVersion;
    
    var mucho = new
    {
        GitVersionInformation.BranchName,
        GitVersionInformation.FullSemVer,
        GitVersionInformation.FullBuildMetaData,
        GitVersionInformation.SemVer,
        GitVersionInformation.InformationalVersion,
        GitVersionInformation.Patch,
        GitVersionInformation.BuildMetaData,
        GitVersionInformation.CommitsSinceVersionSource,
        GitVersionInformation.CommitsSinceVersionSourcePadded,
        GitVersionInformation.CommitDate,
        GitVersionInformation.NuGetVersionV2,
        GitVersionInformation.NuGetVersion,
        GitVersionInformation.NuGetPreReleaseTagV2,
        GitVersionInformation.NuGetPreReleaseTag,
        GitVersionInformation.VersionSourceSha,
    };


    var version = $"{GitVersionInformation.SemVer}";
    return version;
});

app.MapGet("/version/info", () =>
{
    var info = GitVersionInformation.FullBuildMetaData;
    var ginfo = GitVersionInformation.InformationalVersion;

    var version = $"{GitVersionInformation.InformationalVersion}";
    return version;
});

app.Run();
