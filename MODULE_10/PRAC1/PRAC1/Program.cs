using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC1
{
    public class RoomBookingSystem
    {
        public void BookRoom(int roomId)
        {
            Console.WriteLine($"Номер {roomId} забронирован.");
        }

        public void CancelRoomBooking(int roomId)
        {
            Console.WriteLine($"Бронирование номера {roomId} отменено.");
        }
    }

    public class RestaurantSystem
    {
        public void ReserveTable(int tableId)
        {
            Console.WriteLine($"Стол {tableId} зарезервирован.");
        }

        public void OrderFood(string foodItem)
        {
            Console.WriteLine($"Блюдо {foodItem} заказано.");
        }

        public void OrderTaxi()
        {
            Console.WriteLine("Такси вызвано.");
        }
    }

    public class EventManagementSystem
    {
        public void BookConferenceHall(int hallId)
        {
            Console.WriteLine($"Конференц-зал {hallId} забронирован.");
        }

        public void OrderEquipment(string equipment)
        {
            Console.WriteLine($"Оборудование {equipment} заказано.");
        }
    }

    public class CleaningService
    {
        public void ScheduleCleaning(int roomId)
        {
            Console.WriteLine($"Уборка для номера {roomId} запланирована.");
        }

        public void RequestCleaning(int roomId)
        {
            Console.WriteLine($"Уборка для номера {roomId} запрошена.");
        }
    }

    public class HotelFacade
    {
        private RoomBookingSystem roomBookingSystem;
        private RestaurantSystem restaurantSystem;
        private EventManagementSystem eventManagementSystem;
        private CleaningService cleaningService;

        public HotelFacade()
        {
            roomBookingSystem = new RoomBookingSystem();
            restaurantSystem = new RestaurantSystem();
            eventManagementSystem = new EventManagementSystem();
            cleaningService = new CleaningService();
        }

        public void BookRoomWithServices(int roomId, string foodItem)
        {
            roomBookingSystem.BookRoom(roomId);
            restaurantSystem.OrderFood(foodItem);
            cleaningService.ScheduleCleaning(roomId);
            Console.WriteLine("Бронирование номера с услугами ресторана и уборки завершено.\n");
        }

        public void OrganizeEvent(int hallId, int[] roomIds, string equipment)
        {
            eventManagementSystem.BookConferenceHall(hallId);
            foreach (var roomId in roomIds)
            {
                roomBookingSystem.BookRoom(roomId);
            }
            eventManagementSystem.OrderEquipment(equipment);
            Console.WriteLine("Организация мероприятия завершена.\n");
        }

        public void ReserveTableWithTaxi(int tableId)
        {
            restaurantSystem.ReserveTable(tableId);
            restaurantSystem.OrderTaxi();
            Console.WriteLine("Бронирование стола с вызовом такси завершено.\n");
        }

        public void CancelRoom(int roomId)
        {
            roomBookingSystem.CancelRoomBooking(roomId);
            Console.WriteLine("Отмена бронирования номера завершена.\n");
        }

        public void RequestCleaning(int roomId)
        {
            cleaningService.RequestCleaning(roomId);
            Console.WriteLine("Уборка по запросу выполнена.\n");
        }
    }

    public class Program
    {
        public static void Main()
        {
            HotelFacade hotelFacade = new HotelFacade();

            hotelFacade.BookRoomWithServices(101, "Паста");

            hotelFacade.OrganizeEvent(1, new int[] { 101, 102, 103 }, "Проектор");

            hotelFacade.ReserveTableWithTaxi(5);

            hotelFacade.CancelRoom(101);

            hotelFacade.RequestCleaning(102);
        }
    }
}