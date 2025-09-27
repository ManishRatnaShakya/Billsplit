import type {} from '@mui/x-date-pickers/themeAugmentation';
import type {} from '@mui/x-charts/themeAugmentation';
import type {} from '@mui/x-data-grid-pro/themeAugmentation';
import type {} from '@mui/x-tree-view/themeAugmentation';
import {alpha} from "@mui/material/styles";
import Stack from "@mui/material/Stack";
import SideMenu from "../components/SideMenu.tsx";
import AppNavbar from "../components/AppNavbar.tsx";
import CssBaseline from "@mui/material/CssBaseline";
import AppTheme from "./theme/AppTheme.tsx";
import Box from "@mui/material/Box";
import Header from "../components/Header.tsx";

import { Outlet } from "react-router-dom";

import {
    chartsCustomizations,
    dataGridCustomizations,
    datePickersCustomizations,
    treeViewCustomizations,
} from '../layouts/theme/customizations';

const xThemeComponents = {
    ...chartsCustomizations,
    ...dataGridCustomizations,
    ...datePickersCustomizations,
    ...treeViewCustomizations,
};

export default function AppLayout(props: { disableCustomTheme?: boolean }) {
    return (
        <AppTheme {...props} themeComponents={xThemeComponents}>
            <CssBaseline enableColorScheme />
            <Box sx={{ display: 'flex' }}>
                <SideMenu />
                <AppNavbar />
                {/* Main content */}
                <Box
                    component="main"
                    sx={(theme) => ({
                        flexGrow: 1,
                        backgroundColor: theme.vars
                            ? `rgba(${theme.vars.palette.background.defaultChannel} / 1)`
                            : alpha(theme.palette.background.default, 1),
                        overflow: 'auto',
                    })}
                >
                    <Stack
                        spacing={2}
                        sx={{
                            mx: 3,
                            pb: 5,
                            mt: { xs: 8, md: 0 },
                        }}
                    >
                        <Header />
                        <Outlet />
                    </Stack>
                </Box>
            </Box>
        </AppTheme>
    );
}
