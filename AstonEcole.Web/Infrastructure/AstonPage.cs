using AstonEcole.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstonEcole.Web.Infrastructure
{
    public abstract  class AstonPage : System.Web.UI.Page
    {
        protected AstonEcoleApiClient astonApiClient { get; private set; }

        protected AstonPage()
        {
            astonApiClient = new AstonEcoleApiClient();
        }

        // affecte le champ client Api de notre page avec le client api de la page en paramètre
        protected AstonPage(AstonPage otherService)
        {
            astonApiClient = otherService.astonApiClient;
        }
             

        public override void Dispose()
        {
            if (astonApiClient != null)
            {
                astonApiClient.Dispose();
            }
            base.Dispose();
        }
    }
}