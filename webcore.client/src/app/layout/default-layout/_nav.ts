import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: 'NEW'
    }
  },
   //#region System Management
  {
    name: 'System Management',
    title: true
  },
  {
    name: 'Accounts',
    url: '/accounts',
    iconComponent: { name: 'cil-people' }
  },
  {
    name: 'Logs',
    url: '/logs',
    iconComponent: { name: 'cil-book' }
  },
  {
    name: 'Extend',
    url: '/system-management/extension',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Roles',
        url: '/system-management/extension/roles',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Modules',
        url: '/system-management/extension/modules',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Actions',
        url: '/system-management/extension/actions',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Settings',
        url: '/system-management/extension/settings',
        icon: 'nav-icon-bullet'
      }
    ]
  },
  //#endregion
];
