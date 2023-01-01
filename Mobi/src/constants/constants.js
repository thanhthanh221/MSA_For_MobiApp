import icons from "./icons"

const screens = {
    main_layout: "MainLayout",
    home: "Trang chủ",
    evaluate: "Đánh giá",
    my_wallet: 'Ví Cá nhân',
    search: "Tìm kiếm",
    cart: "Giỏ hàng",
    favourite: "Yêu thích",
    track_Your_Order: 'Vị trí đặt hàng',
    notification: "Thông báo",
    coupons: 'Giảm giá',
    settings: 'Cài đặt',
    invite_a_friend: 'Kết bạn',
    help_center: 'Hỗ trợ',
    logout: 'Đăng xuât'
}

const bottom_tabs = [
    {
        id: 0,
        label: screens.home,
    },
    {
        id: 1,
        label: screens.search,
    },
    {
        id: 2,
        label: screens.cart,
    },
    {
        id: 3,
        label: screens.favourite,
    },
    {
        id: 4,
        label: screens.notification,
    },
]

const delivery_time = [
    {
        id: 1,
        label: "10 Phút",
    },
    {
        id: 2,
        label: "20 Phút"
    },
    {
        id: 3,
        label: "30 Phút"
    }
]

const ratings = [
    {
        id: 1,
        label: 1,
    },
    {
        id: 2,
        label: 2,
    },
    {
        id: 3,
        label: 3,
    },
    {
        id: 4,
        label: 4,
    },
    {
        id: 5,
        label: 5,
    }
]

const onboarding_screens = [
    {
        id: 1,
        backgroundImage: require("../assets/images/background_01.png"),
        bannerImage: require("../assets/images/favourite_food.png"),
        title: "Chọn một món ăn yêu thích",
        description: "Khi bạn đặt hàng tại đây, chúng tôi sẽ tặng bạn một phiếu giảm giá, ưu đãi đặc biệt và phần thưởng độc quyền"
    },
    {
        id: 2,
        backgroundImage: require("../assets/images/background_02.png"),
        bannerImage: require("../assets/images/hot_delivery.png"),
        title: "Giao hàng nóng tận nhà",
        description: "Chúng tôi làm cho việc đặt đồ ăn trở nên đơn giản và miễn phí - bất kể bạn đặt hàng trực tuyến hay bằng tiền mặt"
    },
    {
        id: 3,
        backgroundImage: require("../assets/images/background_01.png"),
        bannerImage: require("../assets/images/great_food.png"),
        title: "Nhận thức ăn tuyệt vời",
        description: "Bạn sẽ nhận được món ăn tuyệt vời trong vòng một giờ. Và nhận tín dụng giao hàng miễn phí cho mọi đơn đặt hàng."
    }
]

const job_User = [
    {
        id: 1,
        job: "Nhân viên văn phòng",
        icon: icons.company
    },
    {
        id: 2,
        job: "Nội trợ",
        icon: icons.housewife
    },
    {
        id: 3,
        job: "Làm tự do",
        icon: icons.freelancing
    },
    {
        id: 4,
        job: "Học sinh, sinh viên",
        icon: icons.student
    },
    {
        id: 5,
        job: "Công nhân",
        icon: icons.worker
    },
    {
        id: 6,
        job: "Khác",
        icon: icons.other
    }
]

const tags = [
    {
        id: 1,
        label: "Burger"
    },
    {
        id: 2,
        label: "Fast Food"
    },
    {
        id: 3,
        label: "Pizza"
    },
    {
        id: 4,
        label: "Asian"
    },
    {
        id: 5,
        label: "Dessert"
    },
    {
        id: 6,
        label: "Breakfast"
    },
    {
        id: 7,
        label: "Vegetable"
    },
    {
        id: 8,
        label: "Taccos"
    }
];

const track_order_status = [
    {
        id: 1,
        title: "Xác nhận đặt hàng",
        sub_title: "Đơn đặt hàng của bạn đã được nhận"
    },
    {
        id: 2,
        title: "Đơn hàng đang chuẩn bị",
        sub_title: "Đơn đặt hàng của bạn đã được chuẩn bị"
    },
    {
        id: 3,
        title: "Đang giao hàng",
        sub_title: "Đơn hàng của bạn đang được chuyển đến"
    },
    {
        id: 4,
        title: "Đã giao hàng",
        sub_title: "Chúc bạn ăn ngon miệng"
    },
    {
        id: 5,
        title: "Đánh giá chúng tôi",
        sub_title: "Giúp chúng tôi cải thiện dịch vụ của mình"
    }
]

const Settings = [
    {
        label: "Đổi mật khẩu",
        icon: require('../assets/icons/password.png'),
        onPress: "ChangePassword"
    },
    {
        label: "Tìm kiếm",
        icon: require("../assets/icons/filter.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Thông báo",
        icon: require("../assets/icons/notification.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Thông tin người dùng",
        icon: require("../assets/icons/userInfomation.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Ngôn ngữ",
        icon: require("../assets/icons/globe.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Liên hệ",
        icon: require("../assets/icons/call.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Kiểm tra cập nhật",
        icon: require("../assets/icons/check_update.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Bảo mật tài khoản",
        icon: require("../assets/icons/userSecurity.png"),
        onPress: "ChangePassword"
    },
    {
        label: "Đăng xuất",
        icon: require("../assets/icons/logout.png"),
        onPress: "ChangePassword"
    }
]

const GOOGLE_MAP_API_KEY = "AIzaSyCpN0xxEYjXr7dtnBrYHEl0KvR634nZU2M"

export default {
    screens,
    bottom_tabs,
    delivery_time,
    ratings,
    tags,
    job_User,
    onboarding_screens,
    track_order_status,
    Settings,
    GOOGLE_MAP_API_KEY
}