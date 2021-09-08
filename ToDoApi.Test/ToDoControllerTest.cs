using Xunit;
using ToDoApi.Controllers;

namespace ToDoApi.Test
{
    public class ToDoControllerTest
    {
        [Fact]
        public void ViewDataNotNull()
        {
            ToDoController controller = new ToDoController();

            var result = controller.Get();

            Assert.NotNull(result);
        }
    }
}
