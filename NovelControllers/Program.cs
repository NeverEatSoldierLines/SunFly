using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using MySqlConnector;
using Newtonsoft.Json;
using NovelControllers.Contexts;
using NovelRepositories.Contexts;
using NovelRepositories.Entities;
using NovelRepositories.IRepositories;
using NovelRepositories.Repositories;
using NovelServices.IServices;
using NovelServices.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;


var builder = WebApplication.CreateBuilder(args);

#region 配置日志

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.File($"Logs/{DateTime.Now:yy-MM}/{DateTime.Now:yyyy-M-d dddd}.Log",
        outputTemplate: @"{Timestamp:yyyy-MM-dd HH:mm-ss.fff}[{Level:u3}] {Message:lj}\n{Exception}",
        rollingInterval: RollingInterval.Day, //日志按天保存
        rollOnFileSizeLimit: true,            // 限制单个文件的最大长度
        fileSizeLimitBytes: 10 * 1024,        // 单个文件最大长度10K
        encoding: Encoding.UTF8,              // 文件字符编码
        retainedFileCountLimit: 10            // 最大保存文件数,超过最大文件数会自动覆盖原有文件
        ).CreateLogger();
#endregion

#region 配置跨域策略组

var allowAllPolicy = "allowAllPolicy";
var allowMethodsWithPostPutGet = "allowMethodsWithPostPutGet";


builder.Services.AddCors(options => options.AddDefaultPolicy(  //默认策略,只允许本地的80和443端口访问,允许任何请求头,允许任何方法
    policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:80/","https://localhost:443/").AllowAnyHeader().AllowAnyMethod();
    }));


builder.Services.AddCors(options => options.AddPolicy(allowAllPolicy, //允许所有请求策略
    policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }));

builder.Services.AddCors(options => options.AddPolicy(allowMethodsWithPostPutGet,
    policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:80/","https://localhost:443/").AllowAnyHeader().WithMethods("POST","GET","PUT");
    }));

#endregion

#region 获取数据库连接字符串

var path = builder.Environment.IsDevelopment() ? "appsettings.Development.json" : "appsettings.json";
var config = new ConfigurationBuilder().Add(new JsonConfigurationSource
{
    Path = path ,ReloadOnChange = true
}).Build();
var connStr = config["ConnectionStrings:ConnStrDocker"];
// var str = config.GetConnectionString("ConnStrDocker");//这样也可以
Console.WriteLine($"数据库连接字符串为{connStr}");

#endregion

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 数据库上下文注入
builder.Services.AddDbContext<AdminContext>(optionsBuilder 
    => optionsBuilder.UseMySql(new MySqlConnection(), new MySqlServerVersion(new Version(8, 0, 33))));
builder.Services.AddDbContext<UserContext>(optionsBuilder 
    => optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(8, 0, 33))));
builder.Services.AddDbContext<EditorContext>(optionsBuilder 
    => optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(8, 0, 33))));
// builder.Services.AddDbContext<AllContext>(optionsBuilder 
//     => optionsBuilder.UseMySql("Database=SunFlyDev001;Data Source=localhost;Port=3308;User Id=root;Password=991008sunhao@MYSQL;Charset=utf8;TreatTinyAsBoolean=false;",
//         new MySqlServerVersion(new Version(8, 0, 33))));
#endregion

#region Service依赖注入

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IEditorService, EditorService>();
builder.Services.AddScoped<IUserService, UserService>();


#endregion

#region 数据仓储层依赖注入

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IEditorRepository, EditorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

#region 使用跨域策略组

app.UseCors(allowAllPolicy);//允许所有策略
app.UseCors(allowMethodsWithPostPutGet);//允许post、put、get策略
app.UseCors();//默认策略

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();