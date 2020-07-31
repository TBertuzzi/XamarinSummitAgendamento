using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XamarinSummitAgendamento
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly Pin _pinTokyo = new Pin()
        {
            Type = PinType.Place,
            Label = "Clinica Japsion",
            Address = "Gigante Guerreiro Daileon",
            Position = new Position(35.71d, 139.81d)
        };


        readonly Pin _pinTokyo2 = new Pin()
        {
            Icon = BitmapDescriptorFactory.DefaultMarker(Color.Gray),
            Type = PinType.Place,
            Label = "Clinica Tokyo",
            Address = "Sumida-ku, Tokyo, Japan",
            Position = new Position(35.71d, 139.815d),
            ZIndex = 5,
            
        };

        public MainPage()
        {
            InitializeComponent();

            map.MyLocationEnabled = true;
            map.UiSettings.MyLocationButtonEnabled = true;

            _pinTokyo.IsDraggable = true;
            map.Pins.Add(_pinTokyo);
            map.Pins.Add(_pinTokyo2);
            map.SelectedPin = _pinTokyo;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(_pinTokyo.Position, Distance.FromMeters(5000)), true);

        }

        void map_PinClicked(System.Object sender, Xamarin.Forms.GoogleMaps.PinClickedEventArgs e)
        {
            var pinClicado = "teste";
        }
    }
}
