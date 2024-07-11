﻿namespace AtMonitor.Services;

public interface IAlertService
{
    Task ShowAlertAsync(string title, string message, string cancel = "OK");

    Task<bool> ShowConfirmationAsync(string title, string message, string accept = "OK", string cancel = "Abbrechen");
}
