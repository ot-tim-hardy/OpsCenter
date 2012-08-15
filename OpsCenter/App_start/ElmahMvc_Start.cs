[assembly: WebActivator.PreApplicationStartMethod(typeof(OpsCenter.App_Start.ElmahMvc), "Start")]
namespace OpsCenter.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}