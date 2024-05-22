namespace BreakfastAsync.BreakfastItems;

public class Toast : BreakfastItem{
  public Toast(int slices, string finishedMessage = "toast is ready") {
    NumberOfItems = slices;
    FinishedMessage = finishedMessage;
  }

  public async Task<Toast> MakeToastWithButterAndJamAsync() {
    var toast = await ToastBreadAsync();
    ApplyButter();
    ApplyJam();
    return toast;
  }

  private void ApplyJam() =>
    Console.WriteLine("Putting jam on the toast");

  private void ApplyButter() =>
    Console.WriteLine("Putting butter on the toast");

  private async Task<Toast> ToastBreadAsync() {
    for (int slice = 0; slice < NumberOfItems; slice++) {
      Console.WriteLine("Putting a slice of bread in the toaster");
    }

    Console.WriteLine("Start toasting...");
    await Task.Delay(3000);
    Console.WriteLine("Remove toast from toaster");
    return this;
  }
}
