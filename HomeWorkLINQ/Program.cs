using System.Net.Cache;

namespace HomeWorkLINQ
{
	public class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("\n///////////////////Where///////////////////////\n");

			List<Product> products = new List<Product>()
			{
				new Product { Name = "Apple", Category = "Fruit", Price = 1.00 },
	new Product { Name = "Banana", Category = "Fruit", Price = 0.50 },
	new Product { Name = "Orange", Category = "Fruit", Price = 0.75 },
	new Product { Name = "Milk", Category = "Dairy", Price = 2.50 },
	new Product { Name = "Bread", Category = "Bakery", Price = 1.25 }
			};

			IEnumerable<Product> expensiveProducts = products.Where(p => p.Price > 1.00);

			// Выводим результаты
			Console.WriteLine("Expensive Products:");
			foreach (Product product in expensiveProducts)
			{
				Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
			}

			Console.WriteLine("\n////////////////Select//////////////////////////\n");

			List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

			// Преобразуем числа в их квадраты
			IEnumerable<int> squaredNumbers = numbers.Select(n => n * n);

			// Выводим результаты
			Console.WriteLine("Squared Numbers:");
			foreach (int number in squaredNumbers)
			{
				Console.WriteLine(number);
			}

			Console.WriteLine("\n///////////////FirstOrDefault///////////////////////////\n");

			// Создаем список строк
			List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

			// Находим первую строку, начинающуюся с буквы "B"
			string firstBName = names.FirstOrDefault(n => n.StartsWith("B"));

			// Выводим результаты
			Console.WriteLine($"First name starting with 'B': {firstBName}");

			Console.WriteLine("\n///////////////Any///////////////////////////\n");

			// Создаем список целых чисел
			List<int> numbersAny = new List<int>() { 1, 2, 3, 4, 5 };

			// Проверяем, есть ли в списке четные числа
			bool hasEvenNumbers = numbersAny.Any(n => n % 2 == 0);

			// Выводим результаты
			Console.WriteLine($"Has even numbers: {hasEvenNumbers}");

			Console.WriteLine("\n///////////////Count///////////////////////////\n");

			// Создаем список целых чисел
			List<int> numbersCount = new List<int>() { 1, 2, 3, 4, 5 };

			// Считаем количество элементов в списке
			int count = numbersCount.Count();

			// Выводим результаты
			Console.WriteLine($"Count of numbers: {count}");

			Console.WriteLine("\n///////////////GroupBy///////////////////////////\n");

			var groupedProducts = products.GroupBy(p => p.Category);

			// Выводим результаты
			Console.WriteLine("Products grouped by category:");
			foreach (var group in groupedProducts)
			{
				Console.WriteLine($"Category: {group.Key}");
				foreach (var product in group)
				{
					Console.WriteLine($"\t{product.Name} - {product.Price}");
				}
			}

			Console.WriteLine("\n///////////////OrderBy///////////////////////////\n");

			// Сортируем продукты по цене в порядке возрастания
			IEnumerable<Product> sortedProducts = products.OrderBy(p => p.Price);

			// Выводим результаты
			Console.WriteLine("Products sorted by price:");
			foreach (Product product in sortedProducts)
			{
				Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
			}


			Console.WriteLine("\n///////////////Join///////////////////////////\n");

			// Создаем список клиентов
			List<Customer> customers = new List<Customer>()
				{
					new Customer { Id = 1, Name = "Alice" },
					new Customer { Id = 2, Name = "Bob" },
					new Customer { Id = 3, Name = "Charlie" }
				};

			// Создаем список заказов
			List<Order> orders = new List<Order>()
				{
					new Order { Id = 1, CustomerId = 1, Product = "Apple" },
					new Order { Id = 2, CustomerId = 2, Product = "Banana" },
					new Order { Id = 3, CustomerId = 1, Product = "Orange" }
				};

			// Соединяем списки клиентов и заказов по полю CustomerId
			var customerOrders = customers.Join(
				orders,
				customer => customer.Id,
				order => order.CustomerId,
				(customer, order) => new { CustomerName = customer.Name, OrderProduct = order.Product }
			);

			// Выводим результаты
			Console.WriteLine("Customer Orders:");
			foreach (var customerOrder in customerOrders)
			{
				Console.WriteLine($"Customer: {customerOrder.CustomerName}, Order Product: {customerOrder.OrderProduct}");
			}

			Console.WriteLine("\n///////////////Concat,GroupBy,Sum,Select///////////////////////////\n");

			// Предположим, у нас есть два списка покупок
			List<Purchase> purchases1 = new List<Purchase>()
				{
					new Purchase { Product = "Apple", Quantity = 2 },
					new Purchase { Product = "Milk", Quantity = 1 },
				};

			List<Purchase> purchases2 = new List<Purchase>()
				{
					new Purchase { Product = "Bread", Quantity = 1 },
					new Purchase { Product = "Cheese", Quantity = 1 },
				};

			// Объединяем два списка и группируем по продукту
			var combinedPurchases = purchases1.Concat(purchases2).GroupBy(p => p.Product)
				.Select(g => new
				{
					Product = g.Key,
					TotalQuantity = g.Sum(p => p.Quantity)
				});

			// Вывод
			foreach (var purchase in combinedPurchases)
			{
				Console.WriteLine($"Product: {purchase.Product}, Total Quantity: {purchase.TotalQuantity}");
			}


			Console.WriteLine("\n///////////////Average,GroupBy,Select///////////////////////////\n");

			// Список сотрудников
			List<Employee> employees = new List<Employee>()
				{
					new Employee { Department = "Sales", Salary = 50000 },
					new Employee { Department = "Sales", Salary = 60000 },
					new Employee { Department = "Marketing", Salary = 45000 },
					new Employee { Department = "Marketing", Salary = 55000 },
				};

			// Вычисление средней зарплаты по отделам
			var averageSalaries = employees.GroupBy(e => e.Department)
				.Select(g => new
				{
					Department = g.Key,
					AverageSalary = g.Average(e => e.Salary)
				});

			// Вывод
			foreach (var salary in averageSalaries)
			{
				Console.WriteLine($"Department: {salary.Department}, Average Salary: {salary.AverageSalary}");
			}

			Console.WriteLine("\n///////////////Where///////////////////////////\n");

			// Выбираем продукты, которые относятся к категории "Fruit" и имеют цену меньше $1.00
			var filteredProducts = products.Where(p => p.Category == "Fruit" && p.Price < 1.00);

			// Вывод
			foreach (var product in filteredProducts)
			{
				Console.WriteLine($"Product: {product.Name}, Category: {product.Category}, Price: {product.Price}");
			}

			
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			

			var testOneLinq = new List<TestOneLinq>()
			{
				new TestOneLinq {Quantity = 100, Stroca = "Привет" },
				new TestOneLinq {Quantity = 200, Stroca = "Здраствуй" },
				new TestOneLinq {Quantity = 300, Stroca = "Ку-ку" }
			};

			var testTwoLinq = new List<TestTwoLinq>()
			{
				new TestTwoLinq {Id = 1, Name = "Привет" },
				new TestTwoLinq {Id = 2, Name = "Ку-ку" },
				new TestTwoLinq {Id = 3, Name = "Имя3" }
			};

			Console.WriteLine("--Select--\n");//определяет проекцию выбранных значений
			var resultSelect = testOneLinq.Select(t => t.Stroca);
			foreach (var items in resultSelect)
			{
				Console.WriteLine(items);
			}
			Console.WriteLine("\n--Where--\n");//определяет фильтр выборки

			var resultWhere = testOneLinq.Where(t => t.Quantity > 105);
			foreach (var items in resultWhere)
			{
				Console.WriteLine(items.Stroca);
			}


			Console.WriteLine("\n--OrderBy and OrderByDescending--\n");//упорядочивает элементы по возрастанию,упорядочивает элементы по убыванию

			var resultOrderBy = testOneLinq.OrderBy(t => t.Stroca);
			foreach (var items in resultOrderBy)
			{
				Console.WriteLine(items.Stroca);
			}
			Console.WriteLine();
			var resultOrderByDescending = testOneLinq.OrderByDescending(t => t.Stroca);
			foreach (var items in resultOrderByDescending)
			{
				Console.WriteLine(items.Stroca);
			}

			Console.WriteLine("\n--ThenBy and ThenByDescending--\n");

		//ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

		//ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию

			var resultThenBy = testOneLinq.OrderBy(t => t.Stroca).ThenBy(t => t.Quantity);
			foreach (var items in resultThenBy)
			{
				Console.WriteLine(items.Stroca);
			}

			Console.WriteLine();

			var resultThenByDescending = testOneLinq.OrderByDescending(t => t.Stroca).ThenByDescending(t => t.Quantity);
			foreach (var items in resultThenByDescending)
			{
				Console.WriteLine(items.Stroca);
			}


			Console.WriteLine("\n--Join--\n");//соединяет две коллекции по определенному признаку

			var resultJoin = testOneLinq.Join(testTwoLinq, t1 => t1.Stroca, t2 => t2.Name, (t1, t2) => new { Quantity = t1.Quantity, Stroca = t2.Name, Id = t2.Id });
			
			foreach (var items in resultJoin)
			{	
				Console.WriteLine($"{items.Quantity}, {items.Stroca}, {items.Id}");
			}


			Console.WriteLine("\n-------Aggregate-------\n");//применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту
			int[] numbersAggregate = { 1, 2, 3, 4, 5 };
			int query = numbersAggregate.Aggregate((x, y) => x + y);//x - первый элемент, y - второй элемент
			Console.WriteLine(query);

			Console.WriteLine();


			Console.WriteLine("\n-------GroupBy-------\n");//группирует элементы по ключу

			List<Test> tests = new List<Test>()
			{
				new Test(18,"Woman","Alica"),
				new Test(30,"Man","Vlad"),
				new Test(27,"Woman","Dasha"),
				new Test(50,"Man","Bob"),
				new Test(20,"Woman","Janna"),
				new Test(43,"Man","Vasya"),
			};

			var groupTests = tests.GroupBy(t => t.Category);
			foreach (var group in groupTests)
			{
				Console.WriteLine($"Category: {group.Key}");
				foreach (var human in group)
				{
					human.Show();
				}
			}


			Console.WriteLine("\n-------GroupJoin-------\n");//выполняет одновременно соединение коллекций и группировку элементов по ключу

			var ageGroups = new List<int> { 18, 30, 45, 60 };

			// GroupJoin для соединения по возрасту
			var resultGroupJoin = ageGroups.GroupJoin(
				tests,
				ageGroup => ageGroup, // Ключ для ageGroups - возрастная группа
				test => test.Age,    // Ключ для tests - возраст
				(ageGroup, testGroup) => new { AgeGroup = ageGroup, Tests = testGroup } // Объединение данных
			);

			foreach (var result in resultGroupJoin)
			{
				Console.WriteLine($"Age Group: {result.AgeGroup}");

				
				if (result.Tests.Any())
				{
					foreach (var test in result.Tests)
					{
						test.Show();
					}
				}
				else
				{
					Console.WriteLine("  (Нет людей в этой возрастной группе)");
				}



				Console.WriteLine("\n-------Reverse-------\n");//обратный порядок
				var numbersInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

				Console.WriteLine("Reverse:");
				numbersInt.Reverse();
				foreach (var number in numbersInt)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------All-------\n");// определяет, все ли элементы коллекции удовлятворяют определенному условию

				Console.WriteLine("All:");
				bool areAllEven = numbersInt.All(n => n % 2 == 0);
				Console.WriteLine(areAllEven);


				Console.WriteLine("\n-------Any-------\n");//определяет, удовлетворяет хотя бы один элемент коллекции определенному условию

				Console.WriteLine("Any:");
				bool isAnyEven = numbersInt.Any(n => n % 2 == 0);
				Console.WriteLine(isAnyEven);


				Console.WriteLine("\n-------Contains-------\n");//определяет, содержит ли коллекция определенный элемент


				Console.WriteLine("Contains:");
				bool containsFive = numbersInt.Contains(5);
				Console.WriteLine(containsFive);


				Console.WriteLine("\n-------Distinct-------\n");//удаляет дублирующиеся элементы из коллекции

				Console.WriteLine("Distinct:");
				List<int> distinctNumbers = new List<int> { 1, 1, 2, 3, 3, 4, 5 };
				var resultDistinct = distinctNumbers.Distinct();
				foreach (var number in resultDistinct)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Except-------\n");//возвращает разность двух коллекцию, то есть те элементы, которые создаются только в одной коллекции

				Console.WriteLine("Except:");
				List<int> evenNumbers = new List<int> { 2, 4, 6, 8, 10 };
				var oddNumbers = numbersInt.Except(evenNumbers);
				foreach (var number in oddNumbers)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Union-------\n");//объединяет две однородные коллекции

				var resultUnion = numbersInt.Union(evenNumbers);
				foreach (var number in resultUnion)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Intersect-------\n");//возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях

				Console.WriteLine("Intersect:");
				var resultIntersect = numbersInt.Intersect(evenNumbers);
				foreach (var number in resultIntersect)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Count-------\n");//подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию

				Console.WriteLine("Count:");
				int count1 = numbersInt.Count();
				Console.WriteLine(count1);


				Console.WriteLine("\n-------Sum-------\n");//подсчитывает сумму числовых значений в коллекции

				Console.WriteLine("Sum:");
				int sum = numbersInt.Sum();
				Console.WriteLine(sum);


				Console.WriteLine("\n-------Average-------\n");//подсчитывает cреднее значение числовых значений в коллекции

				Console.WriteLine("Average:");
				double average = numbersInt.Average();
				Console.WriteLine(average);


				Console.WriteLine("\n-------Min-------\n");//находит минимальное значение

				Console.WriteLine("Min:");
				int min = numbersInt.Min();
				Console.WriteLine(min);


				Console.WriteLine("\n-------Max-------\n");//находит максимальное значение

				Console.WriteLine("Max:");
				int max = numbersInt.Max();
				Console.WriteLine(max);


				Console.WriteLine("\n-------Take-------\n");//выбирает определенное количество элементов

				Console.WriteLine("Take:");
				var resultTake = numbersInt.Take(3);
				foreach (var number in resultTake)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Skip-------\n");//пропускает определенное количество элементов

				Console.WriteLine("Skip:");
				var resultSkip = numbersInt.Skip(3);
				foreach (var number in resultSkip)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------TakeWhile-------\n");//возвращает цепочку элементов последовательности, до тех пор, пока условие истинно

				Console.WriteLine("TakeWhile:");
				var resultTakeWhile = numbersInt.TakeWhile(n => n < 5);
				foreach (var number in resultTakeWhile)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------SkipWhile-------\n");//пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы

				Console.WriteLine("SkipWhile:");
				var resultSkipWhile = numbersInt.SkipWhile(n => n < 5);
				foreach (var number in resultSkipWhile)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Concat-------\n");//объединяет две коллекции

				Console.WriteLine("Concat:");
				var resultConcat = numbersInt.Concat(evenNumbers);
				foreach (var number in resultConcat)
				{
					Console.Write(number + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------Zip-------\n");//объединяет две коллекции в соответствии с определенным условием

				Console.WriteLine("Zip:");
				List<string> letters = new List<string> { "A", "B", "C", "D", "E", "F" };
				var zipped = numbersInt.Zip(letters, (num, letter) => num + letter);
				foreach (var item in zipped)
				{
					Console.Write(item + " ");
				}
				Console.WriteLine();


				Console.WriteLine("\n-------First-------\n");//выбирает первый элемент коллекции

				Console.WriteLine("First:");
				int first = numbersInt.First();
				Console.WriteLine(first);


				Console.WriteLine("\n-------FirstOrDefault-------\n");//выбирает первый элемент коллекции или возвращает значение по умолчанию

				Console.WriteLine("FirstOrDefault:");
				List<int> emptyList = new List<int>();
				int firstOrDefault = emptyList.FirstOrDefault();
				Console.WriteLine(firstOrDefault);


				Console.WriteLine("\n-------Single-------\n");//выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, то генерируется исключение

				Console.WriteLine("Single:");
				List<int> singleList = new List<int> { 1 };
				int single = singleList.Single();
				Console.WriteLine(single);


				Console.WriteLine("\n-------SingleOrDefault-------\n");//выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по умолчанию. Если в коллекции больше одного элемента, генерирует исключение

				Console.WriteLine("SingleOrDefault:");
				int singleOrDefault = singleList.SingleOrDefault();
				Console.WriteLine(singleOrDefault);


				Console.WriteLine("\n-------ElementAt-------\n");//выбирает элемент последовательности по определенному индексу

				Console.WriteLine("ElementAt:");
				int elementAtTwo = numbersInt.ElementAt(2);
				Console.WriteLine(elementAtTwo);


				Console.WriteLine("\n-------ElementAtOrDefault-------\n");//выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона

				Console.WriteLine("ElementAtOrDefault:");
				int elementAtOrDefault = numbersInt.ElementAtOrDefault(10);
				Console.WriteLine(elementAtOrDefault);


				Console.WriteLine("\n-------Last-------\n");//выбирает последний элемент коллекции

				Console.WriteLine("Last:");
				int last = numbersInt.Last();
				Console.WriteLine(last);


				Console.WriteLine("\n-------LastOrDefault-------\n");//выбирает последний элемент коллекции или возвращает значение по умолчанию

				Console.WriteLine("LastOrDefault:");
				int lastOrDefault = emptyList.LastOrDefault();
				Console.WriteLine(lastOrDefault);
			}
		}
	}
}