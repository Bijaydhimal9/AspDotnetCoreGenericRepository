using System;
using System.Threading.Tasks;
using AspDotnetCoreGenericRepository.GenericRepository;
using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using static ClientNotifications.Helpers.NotificationHelper;

namespace AspDotnetCoreGenericRepository.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        private readonly IClientNotification _clientNotification;
        public BaseController(IClientNotification clientNotification)
        {
            this._clientNotification = clientNotification;
        }

         public void Notify(string message, NotificationType notificationType)
         {
             _clientNotification.AddToastNotification(message,notificationType,new ToastNotificationOption{
                 PositionClass="toast-top-right"
             });
         }
        public async Task Create(T t,string model, IGenericRepository<T> _repository)
        {
            try{
                await  _repository.CreateAsync(t);
                Notify($"Successfully Created",NotificationType.success);
            }catch(Exception)
            {
                Notify($"Could not Create {model}. Try Again",NotificationType.error);
            }
        }

        public async Task Remove(T t , string model, IGenericRepository<T> _repository)
        {
            try{
                await _repository.DeleteAsync(t);
                Notify($"Successfully Deleted",NotificationType.success);
            }catch(Exception)
            {
                Notify($"Error Try Again",NotificationType.error);
            }
        }

        public async Task Update(T t,string model, IGenericRepository<T> _repository)
        {
            try{
                await _repository.UpdateAsync(t);
                Notify($"Successfully Updated",NotificationType.success);
            }catch(Exception)
            {
                Notify($"Error Try Again",NotificationType.error);
            }
        }
    }
}