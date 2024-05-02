import { CommonDetailsPage } from '@/src/components/Details/CommonDetailsPage';
import { Error } from '@/src/components/Error/Error';
import { ScreenLoader } from '@/src/components/Loader/ScreenLoader';
import { Resident } from '@/src/components/Location/Resident';
import { TableCell } from '@/src/components/Table/TableCell';
import { TableTitle } from '@/src/components/Table/TableTitle';
import { LOCATION_IMAGE_URL } from '@/src/constants/images';
import { useGetDataById } from '@/src/hooks/useGetDataById';
import { endpoints } from '@/src/routes/routes';
import { detailsPageStyles } from '@/src/styles/details';
import { Location } from '@/src/types/location';
import { useLocalSearchParams } from 'expo-router';
import React from 'react';
import { Text } from 'react-native';
import { DataTable } from 'react-native-paper';

export default function LocationDetails() {
  const { id } = useLocalSearchParams();

  const { loading, error, data } = useGetDataById<Location>(
    endpoints.locations,
    id as string
  );

  if (loading) {
    return <ScreenLoader />;
  }

  if (error) {
    return <Error errorMsg={error} />;
  }

  const { name, type, dimension, residents } = data ?? {};

  return (
    <CommonDetailsPage imageUrl={LOCATION_IMAGE_URL}>
      <Text style={detailsPageStyles.name}>{name}</Text>
      <DataTable>
        <DataTable.Header>
          <TableTitle title='Type' />
          <TableTitle title='Dimension' />
        </DataTable.Header>
        <DataTable.Row>
          <TableCell value={type} />
          <TableCell value={dimension} />
        </DataTable.Row>
      </DataTable>
      <DataTable>
        <DataTable.Header>
          <TableTitle title='Residents' />
        </DataTable.Header>
        {residents?.map((r) => (
          <DataTable.Row key={r}>
            <Resident id={r.slice(r.lastIndexOf('/') + 1)} />
          </DataTable.Row>
        ))}
      </DataTable>
    </CommonDetailsPage>
  );
}
