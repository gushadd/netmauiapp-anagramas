#if ANDROID

using Microsoft.Maui.Controls.Compatibility.Platform.Android;
            
#endif

namespace Anagramas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Remover sublinhado de 'Editor'
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());


#endif
            });
          
            MainPage = new AppShell();
        }
    }
}
