
using FiboAddress.InfraStructure.Assembler;
using FiboAddress.InfraStructure.Repository;
using FiboAddress.InfraStructure.Service;

using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Data;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.InfraStructure.Service;
using FiboSchool.InfraStructure.Assembler;
using FiboSchool.InfraStructure.Repository;
using FiboSchool.InfraStructure.Service;
using FiboUser.InfraStructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolResultManagementSystem.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SchoolManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SchoolManagementSystem"), x => x.MigrationsAssembly("FiboInfraStructure")));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
            });
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

          


            //Provience
            services.AddTransient<IProvienceRepository, ProvienceRepository>();
            services.AddTransient<IProvienceService, ProvienceService>();
            services.AddTransient<IProvienceAssembler, ProvienceAssembler>();

            //District
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IDistrictAssembler, DistrictAssembler>();


            //LocalLevel
            services.AddTransient<ILocalLevelRepository, LocalLevelRepository>();
            services.AddTransient<ILocalLevelService, LocalLevelService>();
            services.AddTransient<ILocalLevelAssembler, LocalLevelAssembler>();

            //Office
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IOfficeAssembler, OfficeAssembler>();
            services.AddTransient<IOfficeService, OfficeService>();

            //Branch
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IBranchAssembler, BranchAssembler>();
            services.AddTransient<IBranchService, BranchService>();

            //FiscalYear
            services.AddTransient<IFiscalYearRepository, FiscalYearRepository>();
            services.AddTransient<IFiscalYearService, FiscalYearService>();
            services.AddTransient<IFiscalYearAssembler, FiscalYearAssembler>();


            services.AddTransient<IUserBranchService, UserBranchService>();
            services.AddTransient<IUserBranchRepository, UserBranchRepository>();

            //School//
            services.AddTransient<ISchoolSetupAssembler, SchoolSetupAssembler>();
            services.AddTransient<ISchoolSetupRepository, SchoolSetupRepository>();
            services.AddTransient<ISchoolSetupService, SchoolSetupService>();

            //ClassSetup
            services.AddTransient<IClassSetupAssembler, ClassSetupAssembler>();
            services.AddTransient<IClassSetupRepository, ClassSetupRepository>();
            services.AddTransient<IClassSetupService, ClassSetupService>();

            //SectionSetup
            services.AddTransient<ISectionSetupRepository, SectionSetupRepository>();
            services.AddTransient<ISectionSetupAssembler, SectionSetupAssembler>();
            services.AddTransient<ISectionSetupService, SectionSetupService>();

            //Student
            services.AddTransient<IStudentAssembler, StudentAssembler>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();

            //Session//
            services.AddTransient<ISessionSetupAssembler, SessionSetupAssembler>();
            services.AddTransient<ISessionSetupRepository, SessionSetupRepository>();
            services.AddTransient<ISessionSetupService, SessionSetupService>();

            //Subject//
            services.AddTransient<ISubjectAssembler, SubjectAssembler>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ISubjectService, SubjectService>();

            //Teacher//
            services.AddTransient<ITeacherAssembler, TeacherAssembler>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherService, TeacherService>();

            //AssignTeacher//
            services.AddTransient<IAssignTeacherAssembler, AssignTeacherAssembler>();
            services.AddTransient<IAssignTeacherRepository, AssignTeacherRepository>();
            services.AddTransient<IAssignTeacherService, AssignTeacherService>();

            //Term
            services.AddTransient<ITermAssembler, TermAssembler>();
            services.AddTransient<ITermRepository, TermRepository>();
            services.AddTransient<ITermService, TermService>();

            //Performance
            services.AddTransient<IPerformanceAssembler, PerformanceAssembler>();
            services.AddTransient<IPerformanceRepository, PerformanceRepository>();
            services.AddTransient<IPerformanceService, PerformanceService>();

            //ManageMarks
            services.AddTransient<IManageMarksAssembler, ManageMarksAssembler>();
            services.AddTransient<IManageMarksRepository, ManageMarksRepository>();
            services.AddTransient<IManageMarksService, ManageMarksService>();


            //ManageMarksDetail
            services.AddTransient<IManageMarksDetailAssembler, ManageMarksDetailAssembler>();
            services.AddTransient<IManageMarksDetailRepository, ManageMarksDetailRepository>();
            services.AddTransient<IManageMarksDetailService, ManageMarksDetailService>();

            services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = false;
            })

          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.Cookie.IsEssential = true;
                options.SlidingExpiration = true; // here 1
                options.ExpireTimeSpan = TimeSpan.FromSeconds(10);// here 2
            });


            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //SeedRoles(serviceProvider).Wait();

            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
               
                endpoints.MapControllerRoute(
                name: "reportcards",
                pattern: "reportcards",
                defaults: new { controller = "DashBoard", action = "Index" });
            });
        }
    }
}


