using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
#if (UseRealm)
using Realms;
#endif
#if (UseAzureMobileClient)
using AzureMobileClient.Helpers;
#endif
#if (UseMvvmHelpers)
using MvvmHelpers;
#endif

namespace Company.MobileApp.Models
{
    #if (UseRealm)
    public class TodoItem : RealmObject
    #elseif (UseAzureMobileClient)
    public class TodoItem : EntityData
    #elseif (UseMvvmHelpers)
    public class TodoItem : ObservableObject
    #else
    public class TodoItem : INotifyPropertyChanged
    #endif
    {
        public string Name { get; set; }

        public bool Done { get; set; }
#if (!UseAzureMobileClient && !UseRealm && !UseMvvmHelpers)

        public event PropertyChangedEventHandler PropertyChanged;
#endif
    }
}