using MassTransit;
using Market.Domain.Events;
using EventBus.Messages.Events;
using Market.Application.Interfaces;
using Market.Domain.Model;
using Market.Domain.Interface;

namespace Market.Application.Api.Consumers
{
    public class OrderCreactedConsumer : IConsumer<OrderCheckoutEvent>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderCreactedConsumer(IAsyncRepository<Product> productRepository,
                                     IPublishEndpoint publishEndpoint)
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
                    Product product = await productRepository.GetByIdAsync(pro.productId);

                    // Update lại số lượng sản phẩm
                    product.OrderSagaCoutProduct(pro.count + product.Quantity);
                    await productRepository.UpdateAsync(product);

                    // gửi tin nhắn ngược lại về Order
                    
                }
                return;
            }
            foreach (var pro in context.Message.products) {
                Product product = await productRepository.GetByIdAsync(pro.productId);

                // không tìm thấy sản phẩm
                if (product is null) {
                    context.Message.checkOrchestration = false;
                    context.Message.MessageError = $"Khong tim thay san pham Id : {pro.productId}";

                    await publishEndpoint.Publish<OrderCheckoutEvent>(context.Message);
                    Console.WriteLine(context.Message.MessageError);
                    return;
                }

                // check Count Product

                if (product.Quantity < pro.count) {
                    context.Message.checkOrchestration = false;
                    context.Message.MessageError = $"Kho khong du san pham Id: {pro.productId}";

                    await publishEndpoint.Publish<OrderCheckoutEvent>(context.Message);
                    Console.WriteLine(context.Message.MessageError);
                    return;
                }
                else if (product.Quantity >= pro.count) {
                    product.OrderSagaCoutProduct(pro.count);
                    await productRepository.UpdateAsync(product);
                    context.Message.price += pro.count * product.Price;

                    // Update Product
                }
            }
            Console.WriteLine($"Update Price for Product Check true");
            Console.WriteLine("Price: " + context.Message.price);
            await publishEndpoint.Publish<OrderCheckoutEvent>(context.Message);
        }
    }
}
