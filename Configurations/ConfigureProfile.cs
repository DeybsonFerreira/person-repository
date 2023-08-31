using app.Configurations.AutoMapperProfile;
using AutoMapper;

namespace app.Configurations
{
    public static class ConfigureProfile
    {
        public static WebApplicationBuilder ConfigureAutoMapper(this WebApplicationBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonProfile());
            });

            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
            return builder;
        }
    }
}