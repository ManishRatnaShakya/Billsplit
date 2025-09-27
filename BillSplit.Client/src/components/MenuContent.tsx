import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Stack from '@mui/material/Stack';
import HomeRoundedIcon from '@mui/icons-material/HomeRounded';
import AnalyticsRoundedIcon from '@mui/icons-material/AnalyticsRounded';
import PeopleRoundedIcon from '@mui/icons-material/PeopleRounded';
import AssignmentRoundedIcon from '@mui/icons-material/AssignmentRounded';
import SettingsRoundedIcon from '@mui/icons-material/SettingsRounded';
import InfoRoundedIcon from '@mui/icons-material/InfoRounded';
import HelpRoundedIcon from '@mui/icons-material/HelpRounded';
import {useLocation, useNavigate} from "react-router-dom";

const mainListItems = [
  { text: 'Home', icon: <HomeRoundedIcon />, path: '/dashboard'}, 
  { text: 'Friends', icon: <PeopleRoundedIcon />, path: '/friends'}, 
  { text: 'Trips', icon: <AssignmentRoundedIcon />, path: '/trips'},
  { text: 'Analytics', icon: <AnalyticsRoundedIcon />, path: '/analytics' },
];

const secondaryListItems = [
  { text: 'Settings', 
      icon: <SettingsRoundedIcon />, path: '/settings' },
  { text: 'About', icon: <InfoRoundedIcon />, path: '/about' },
  { text: 'Feedback', icon: <HelpRoundedIcon />, path: '/feedback' },
];

export default function MenuContent() {
    const navigate = useNavigate();
    const location = useLocation();

    return (
        <Stack sx={{ flexGrow: 1, p: 1, justifyContent: "space-between" }}>
            <List dense>
                {mainListItems.map((item) => (
                    <ListItem key={item.text} disablePadding sx={{ display: "block" }}>
                        <ListItemButton
                            onClick={() => navigate(item.path)}
                            selected={location.pathname === item.path}
                        >
                            <ListItemIcon>{item.icon}</ListItemIcon>
                            <ListItemText primary={item.text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>

            <List dense>
                {secondaryListItems.map((item) => (
                    <ListItem key={item.text} disablePadding sx={{ display: "block" }}>
                        <ListItemButton
                            onClick={() => navigate(item.path)}
                            selected={location.pathname === item.path}
                        >
                            <ListItemIcon>{item.icon}</ListItemIcon>
                            <ListItemText primary={item.text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </Stack>
  );
}
