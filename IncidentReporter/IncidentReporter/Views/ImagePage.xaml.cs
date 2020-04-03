using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentReporter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IncidentReporter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImagePage : ContentPage
	{
	    private Incident _incident;
		public ImagePage (Incident incident)
		{
		    InitializeComponent ();
		    _incident = incident;
		    BindingContext = _incident;
		}
        
	
	}
}