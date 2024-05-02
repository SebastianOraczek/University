import { View, Modal, StyleSheet, Pressable, Text } from 'react-native';
import React, { PropsWithChildren } from 'react';
import { buttonColor } from '@/src/constants/Colors';

interface FilterModalProps extends PropsWithChildren {
  isModalVisible: boolean;
  handleOnPress: () => void;
}

export const FilterModal: React.FC<FilterModalProps> = ({
  isModalVisible,
  handleOnPress,
  children,
}) => (
  <Modal animationType='slide' transparent visible={isModalVisible}>
    <View style={styles.centeredView}>
      <View style={styles.modalView}>
        {children}
        <Pressable style={styles.button} onPress={handleOnPress}>
          <Text style={styles.textStyle}>Filter</Text>
        </Pressable>
      </View>
    </View>
  </Modal>
);

const styles = StyleSheet.create({
  centeredView: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  modalView: {
    backgroundColor: 'white',
    minWidth: 350,
    borderRadius: 20,
    padding: 35,
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 4,
    elevation: 5,
  },
  button: {
    borderRadius: 20,
    padding: 10,
    elevation: 2,
    marginTop: 20,
    backgroundColor: buttonColor,
  },
  textStyle: {
    color: 'white',
    fontWeight: 'bold',
    textAlign: 'center',
  },
});
