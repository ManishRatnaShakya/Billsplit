import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import { Chip, IconButton } from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
type CustomizedDataGridProps = {
    rows: Array<any>;
    columns: Array<GridColDef>;
    onEdit?: (row: any) => void;
    onDelete?: (row: any) => void;
};

export default function CustomizedDataGrid({
                                               rows,
                                               columns,
                                               onEdit,
                                               onDelete,
                                           }: CustomizedDataGridProps) {
    // Enhance incoming columns by adding status + actions
    const enhancedColumns: GridColDef[] = [
        ...columns,
        {
            field: "status",
            headerName: "Status",
            flex: 1,
            minWidth: 120,
            renderCell: (params) => (
                <Chip
                    label={params.value}
                    color={params.value === "active" ? "success" : "error"}
                    size="small"
                    variant="outlined"
                />
            ),
        },
        {
            field: "actions",
            headerName: "Actions",
            flex: 1,
            minWidth: 150,
            sortable: false,
            filterable: false,
            renderCell: (params) => (
                <>
                    <IconButton
                        color="primary"
                        onClick={() => onEdit?.(params.row)}
                        size="small"
                    >
                        <EditIcon fontSize="small" />
                    </IconButton>
                    <IconButton
                        color="error"
                        onClick={() => onDelete?.(params.row)}
                        size="small"
                    >
                        <DeleteIcon fontSize="small" />
                    </IconButton>
                </>
            ),
        },
      
    ];

        
    return (
        <DataGrid
            checkboxSelection
            rows={rows}
            columns={enhancedColumns}
            getRowId={(row) => row.id || row.email} // 👈 ensure unique id
            getRowClassName={(params) =>
                params.indexRelativeToCurrentPage % 2 === 0 ? "even" : "odd"
            }
            initialState={{
                pagination: { paginationModel: { pageSize: 20 } },
            }}
            pageSizeOptions={[10, 20, 50]}
            disableColumnResize
            density="compact"
            slotProps={{
                filterPanel: {
                    filterFormProps: {
                        logicOperatorInputProps: {
                            variant: "outlined",
                            size: "small",
                        },
                        columnInputProps: {
                            variant: "outlined",
                            size: "small",
                            sx: { mt: "auto" },
                        },
                        operatorInputProps: {
                            variant: "outlined",
                            size: "small",
                            sx: { mt: "auto" },
                        },
                        valueInputProps: {
                            InputComponentProps: {
                                variant: "outlined",
                                size: "small",
                            },
                        },
                    },
                },
            }}
        />
    );
}
