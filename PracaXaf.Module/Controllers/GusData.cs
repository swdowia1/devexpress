using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using GusWCF;
using PracaXaf.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using PracaXaf.Module.Help;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace PracaXaf.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class GusData : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public GusData()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            //Specify the type of objects that can use the Controller
            TargetObjectType = typeof(GUS);
            SimpleAction clearTasksAction = new SimpleAction(this, "GusTask", PredefinedCategory.View)
            {
                //Specify the Action's button caption.
                Caption = "Dane z GUS",
                //Specify the confirmation message that pops up when a user executes an Action.
                // ConfirmationMessage = "Are you sure you want to clear the Tasks list?",
                //Specify the icon of the Action's button in the interface.
                ImageName = "Action_Clear"
            };
            //This event fires when a user clicks the Simple Action control.
            clearTasksAction.Execute += GusTask;
        }

        private void GusTask(object sender, SimpleActionExecuteEventArgs e)
        {
            var gusView = (GUS)View.CurrentObject;




            UslugaBIRzewnPublClient bir = new UslugaBIRzewnPublClient();
            bir.Endpoint.Address = new System.ServiceModel.EndpointAddress(@"https://Wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc");

            System.ServiceModel.WSHttpBinding binding = (System.ServiceModel.WSHttpBinding)bir.Endpoint.Binding;
            binding.Security.Mode = System.ServiceModel.SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.None;
            binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Mtom;

            string sid = bir.Zaloguj("abcde12345abcde12345");
            OperationContextScope scope = new OperationContextScope(bir.InnerChannel);

            HttpRequestMessageProperty requestProperties = new HttpRequestMessageProperty();
            requestProperties.Headers.Add("sid", sid);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestProperties;

            ParametryWyszukiwania nipData = new ParametryWyszukiwania();


            nipData.Nip = gusView.Nip;

            string daneSzukajResponse = "9530307834";
            try
            {
                daneSzukajResponse = bir.DaneSzukaj(nipData);
                int k = 124;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            DaneRaportPrawna daneRaportPrawna = null;
            if (!string.IsNullOrEmpty(daneSzukajResponse))
            {
                daneRaportPrawna = DaneRaportPrawna.Deserialize(daneSzukajResponse);
                gusView.Miejscowosc = daneRaportPrawna.dane.Miejscowosc;

                gusView.Regon = daneRaportPrawna.dane.Regon;

                gusView.Nazwa = daneRaportPrawna.dane.Nazwa;

            }


        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
