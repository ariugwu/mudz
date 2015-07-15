﻿using Mudz.Common.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class FinalizeHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            if (actionContext.GameRequest.GameAction == GameActions.Login) return actionContext;

            actionContext.Player.CheckState();

            if (actionContext.Target != null) actionContext.Target.CheckState();

            return actionContext;
        }
    }
}