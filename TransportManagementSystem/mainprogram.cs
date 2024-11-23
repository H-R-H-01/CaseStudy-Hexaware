using System;
using System.Data.SqlClient;
using TransportManagementSystem.Utilities;
using TransportManagementSystem.Services;
using TransportManagementSystem.MainApp;
using TransportManagementSystem.Exceptions;

namespace TransportManagementSystem
{
    public class mainprogram
    {
        public static void Main(string[] args)
        {
            TransportManagementApp app = new TransportManagementApp();
            app.menu();
        }
    }
}
