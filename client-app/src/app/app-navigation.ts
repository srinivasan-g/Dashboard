export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Dash board',
    icon: 'folder',
    items: [
      {
        text: 'Add Employee',
        path: '/profile'
      },
      {
        text: 'Product',
        path: '/product'
      }
    ]
  }
];
export const ColCountByScreen = {
  xs: 1,
  sm: 2,
  md: 3,
  lg: 4
};