﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Noty.FeatureFolders.Models;
using NToastNotify;

namespace Noty.FeatureFolders.Features.Home
{
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            _toastNotification.AddSuccessToastMessage();
            _toastNotification.AddErrorToastMessage("Test m'e'ssag'e with single q'oute", new NotyOptions()
            {
                Timeout = 0,
                Layout = "topLeft",
                Theme = "mint"
            });


            //Info
            _toastNotification.AddInfoToastMessage(null, new NotyOptions
            {
                Layout = "bottomLeft" 
            });
            _toastNotification.AddInfoToastMessage("This is an info toast", new NotyOptions()
            {
                ProgressBar = false,
                Layout ="center"
            });

            //Warning
            _toastNotification.AddWarningToastMessage("Waring go bottom right", new NotyOptions()
            {
                Layout = "bottomRight"
            });

            //Error
            _toastNotification.AddErrorToastMessage("Custom Error Message", new NotyOptions() { Theme = "mint" });


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _toastNotification.AddAlertToastMessage("My About Warning Message");
            return View();
        }

        public IActionResult Empty()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            _toastNotification.AddInfoToastMessage("Dont get confused. <br /> <strong>You were redirected from Contact Page. <strong/>");
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("There was something wrong with this request.");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ajax()
        {
            _toastNotification.AddInfoToastMessage("This page will make ajax requests and's show notifications.");
            return View();
        }

        public IActionResult AjaxCall()
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax's request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView", "Ajax Call");
        }

        public IActionResult NormalAjaxCall()
        {
            return PartialView("_PartialView", "Normal Ajax's Call");
        }

        public IActionResult ErrorAjaxCall()
        {
            throw new Exception("Error occurred");
        }
    }
}
