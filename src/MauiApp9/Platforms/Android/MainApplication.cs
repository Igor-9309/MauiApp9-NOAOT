using Android.App;
using Android.Runtime;

namespace MauiApp9
{
    [Application]
    public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override void OnCreate()
        {
            base.OnCreate();

            using var scope = IPlatformApplication.Current.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MobileDbContext>();
            context.Database.EnsureCreated();
        }
    }
}
