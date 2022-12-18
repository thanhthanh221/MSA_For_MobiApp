using MassTransit;
using EventBus.Messages.Events;
using Application.Common.Repository;
using Market.Domain.ProductService.Model;

namespace Market.Application.Consumers
{
    public class OrderCreactedConsumer : IConsumer<OrderCheckoutEvent>
    {
        private readonly IRepository<ProductAggregate> productRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderCreactedConsumer(
            IRepository<ProductAggregate> productRepository, IPublishEndpoint publishEndpoint)
        {
            this.productRepository = productRepository;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderCheckoutEvent> context)
        {
            context.Message.CountCheckSaga++;
            // xử lý có lỗi
            if (!context.Message.checkOrchestration) {
                // services # bị lỗi => rerun lại dữ liệu cũ
                foreach (var pro in context.Message.products) {
                    var product = await productRepository.GetByIdAsync(pro.productId);
                    await productRepository.UpdateAsync(product);

                    // gửi tin nhắn ngược lại về Order

                }
                return;
            }
            foreach (var pro in context.Message.products) {
                var product = await productRepository.GetByIdAsync(pro.productId);

                // không tìm thấy sản phẩm
                if (product is null) {
                    context.Message.checkOrchestration = false;
                    context.Message.MessageError = $"Khong tim thay san pham Id : {pro.productId}";

                    await publishEndpoint.Publish<OrderCheckoutEvent>(context.Message);
                    Console.WriteLine(context.Message.MessageError);
                    return;
                }
            }
            Console.WriteLine($"Update Price for Product Check true");
            Console.WriteLine("Price: " + context.Message.price);
            await publishEndpoint.Publish<OrderCheckoutEvent>(context.Message);
        }
    }
}
