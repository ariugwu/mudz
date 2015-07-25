using Mudz.Common.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Extensions
{
    public static class ActionResultExtension
    {
        public static IActionResult FillResult(this IActionResult actionResult, IActionContext actionContext, int amount)
        {
            actionResult.WasSuccessful = true;
            actionResult.RoomMessage = HiveMind.Instance.RoomMessage.GetResource(actionContext, amount);
            actionResult.PlayerMessage = HiveMind.Instance.PlayerMessage.GetResource(actionContext, amount);
            actionResult.Amount = amount;

            return actionResult;
        }
    }
}
