using Mediator.Mediator.Abstraction;
using Mediator.Model;
using Mediator.Repositories.Abstraction;
using Mediator.Services.Abstraction;

namespace Mediator.Mediator
{
    public class OrderMediator : IOrderMediator
    {
        private readonly IUserRepository _userRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly INotificationService _notification;
        private readonly ILoggingService _logger;

        public OrderMediator(
            IUserRepository userRepo,
            IOrderRepository orderRepo,
            INotificationService notification,
            ILoggingService logger)
        {
            _userRepo = userRepo;
            _orderRepo = orderRepo;
            _notification = notification;
            _logger = logger;
        }

        public void CreateOrder(int userId, decimal amount)
        {
            _logger.Log("Rozpoczynam tworzenie zamówienia...");

            var user = _userRepo.GetById(userId);

            if (user == null)
                throw new Exception("Użytkownik nie istnieje");

            if (!user.IsActive)
                throw new Exception("Użytkownik jest nieaktywny");

            var order = new Order
            {
                UserId = userId,
                Amount = amount,
                CreatedAt = DateTime.UtcNow
            };

            _orderRepo.Add(order);

            _notification.Send(user.Email, $"Twoje zamówienie na {amount} zostało utworzone.");

            _logger.Log("Zamówienie utworzone pomyślnie.");
        }
    }

}
