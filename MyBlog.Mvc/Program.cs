using MyBlog.Services.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAutoMapper(typeof(EducationProfile), typeof(ExperienceProfile), typeof(ReferanceProfile), typeof(SkillProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseStatusCodePages();
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "User",
		areaName: "User",
		pattern: "User/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapDefaultControllerRoute();
	//endpoints.MapControllerRoute(
	//	name: "default",
	//	pattern: "{controller=Home}/{action=Index}/{id?}"
	//	);

});

app.Run();
