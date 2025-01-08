using System;
using UnityEngine;

namespace RPG_Template
{
    public class HandlerInfoArgs : EventArgs
    {
        public EventHandler<HandlerInfoArgs> eventHandler;
    }

}