﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using PinBuster.Data;
using PinBuster.Pages;
using PinBuster;
namespace PinBuster
{
    public class App : Application
    {
      

        private readonly static Locator _locator = new Locator();

        public static PinsManager PinsManager { get; private set; }

        public static Locator Locator
        {
            get { return _locator; }
        }

        public static IGetCurrentPosition loc;
        public static double lat, lng;
        public static int screenWidth, screenHeight;
        public static ContentPage mapPage;
        public static TabbedPage listView;
        public static string town;

        public App()
        {
            lat = 0;
            lng = 0;
            loc = DependencyService.Get<IGetCurrentPosition>();
            loc.locationObtained += (object sender, ILocationEventArgs e) =>
            {
                lat = e.lat;
                lng = e.lng;
            };
            loc.IGetCurrentPosition();

            // The root page of your application
            PinsManager = new PinsManager();
            mapPage = new MapPage();
            listView = new MessageListView();
            MainPage = new MasterDetail();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            
        }
    }
}
