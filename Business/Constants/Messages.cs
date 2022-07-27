using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants {
    public static class Messages {
        public static string NameInvalid = "Name is invalid";
        public static string MaintenanceTime = "System is in maintenance";
        public static string CarAdded = "Car successfully added";
        public static string CarsListed = "Cars had been listed";
        public static string CarDeleted = "Car successfully deleted";
        public static string CarUpdated = "Car successfully updated";
        public static string UserAdded = "User successfully added";
        public static string UserListed = "Users had been listed";
        public static string UserDeleted = "User successfully deleted";
        public static string UserUpdated = "User successfully updated";
        public static string RentalAdded = "User successfully added";
        public static string RentalListed = "Rentals had been listed";
        public static string RentalDeleted = "Rental successfully deleted";
        public static string RentalUpdated = "Rental successfully updated";
        public static string CustomerAdded = "Customer successfully added";
        public static string CustomerListed = "Customers had been listed";
        public static string CustomerDeleted = "Customer successfully deleted";
        public static string CustomerUpdated = "Customer successfully updated";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is wrong";
        public static string SuccesfullLogin = "Succesfully logged in";
        public static string UserAlreadyExists = "User Already Exists";
        public static string AccessTokenCreated = "Access token has created";
        public static string UserRegistered = "Succesfully registered";
        public static string AuthorizationDenied = "Authorization Denied";
        public static string FilteredItemsListed = "Filtered Items Listed";
        public static string CarRented ="Car Succesfully Rented";
        public static string BalanceInsufficent = "Balance is Insufficent";

        public static string ReturnDateLessThanRentDate { get; internal set; }
        public static string CarAlreadyRented { get; internal set; }
        public static string CustomerHasNoNationalIdentity { get; internal set; }
        public static string FindexScoreInsufficient { get; internal set; }
    }
}
