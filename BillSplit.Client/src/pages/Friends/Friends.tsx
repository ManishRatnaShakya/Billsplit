import CustomizedDataGrid from "../../components/CustomizedDataGrid.tsx";
import {useMemo} from "react";

export default function Friends () {
    const listColumn = ['Name', 'Email', 'Phone'];
    const rows = [{
        name: 'Manish',
        email: 'ManishShakya@gmail.com',
        phone: '0426659136',
        status: 'active',
        id: 1
    },
        {
            name: 'Manish',
            email: 'ManishShakya@gmail.com',
            phone: '0426659136',
            status: 'active',
            id: 3
        },
        {
            name: 'Manish',
            email: 'ManishShakya@gmail.com',
            phone: '0426659136',
            status: 'active',
            id: 2
        }]
    const columns = useMemo(
        () =>
            listColumn.map((column) => (
                ColumnBuilder(column)
            )),
        []
    );
    return (
        <div>
          <CustomizedDataGrid columns={columns}
                              rows={rows}/>
        </div>
    )
}

export function ColumnBuilder(field: string,  flex: number = 1,  minWidth: number = 150) {
    return (
        {field: field.toLowerCase(), headerName: field, minWidth, flex }
    )
}