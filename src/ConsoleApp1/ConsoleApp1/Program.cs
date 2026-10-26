using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «Строй-Мастер».
    /// Компания продаёт стройматериалы.
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Процент скидки для товаров без заказов в прошлом месяце.
        /// </summary>
        public const decimal DiscountPercent = 10m;

        /// <summary>
        /// Название компании-заказчика.
        /// </summary>
        public string CompanyName { get; } = "Строй-Мастер";

        /// <summary>
        /// Рассчитывает цену со скидкой 10%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара (должна быть неотрицательной).</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы по товару в прошлом месяце.</param>
        /// <returns>Цена со скидкой или базовая цена, если скидка не положена.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="basePrice"/> отрицательна.
        /// </exception>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (basePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(basePrice), "Цена не может быть отрицательной.");

            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountPercent / 100m);
        }
    }

    /// <summary>
    /// Точка входа консольного приложения лабораторной работы № 7.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Запускает демонстрацию расчёта скидки и выводит результат в консоль.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            var calculator = new DiscountCalculator();

            decimal price = 1000m;
            decimal discounted = calculator.GetDiscountedPrice(price, hasOrdersLastMonth: false);

            Console.WriteLine($"Компания: {calculator.CompanyName}");
            Console.WriteLine($"Базовая цена: {price}");
            Console.WriteLine($"Цена со скидкой {DiscountCalculator.DiscountPercent}%: {discounted}");
            Console.WriteLine();
            Console.WriteLine("Автор: Сергеев Д.В, группа И-43"); 
            Console.ReadKey();
        }
    }
}
