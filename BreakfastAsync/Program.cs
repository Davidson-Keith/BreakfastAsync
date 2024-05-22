using BreakfastAsync.BreakfastItems;

namespace BreakfastAsync {
  /**
   * Playing with Microsoft's Learning page "Asynchronous programming with async and await":
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
   */
  class Program {
    static async Task Main(String[] args) {
      new Coffee().PourCoffee();
      Task eggsTask = new Eggs(2).FryEggsAsync();
      Task baconTask = new Bacon(3).FryBaconAsync();
      Task toastTask = new Toast(2).MakeToastWithButterAndJamAsync();
      Task.WaitAll([eggsTask, baconTask, toastTask]);
      // This is how they did it in the tutorial, but the single line above does the same.
      // List<Task> breakfastTasks = [eggsTask, baconTask, toastTask];
      // while (breakfastTasks.Count > 0) {
      //   Task finishedTask = await Task.WhenAny(breakfastTasks);
      //   // await finishedTask;
      //   breakfastTasks.Remove(finishedTask);
      // }
      new Juice().PourOJ();
      Console.WriteLine("Breakfast is ready!");
    }
  }
}

  
  