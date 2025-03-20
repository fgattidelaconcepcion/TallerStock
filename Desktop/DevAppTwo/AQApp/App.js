import { useState } from 'react';
import { TextInput, Text, View, Button, ImageBackground, StyleSheet } from 'react-native';

const productsExample = [
  { id: 1, value: "Mate" },
  { id: 2, value: "Cafe" },
  { id: 3, value: "Harina" },
  { id: 4, value: "Palmitos" },
  { id: 5, value: "Yerba" },
  { id: 6, value: "Mermelada" },
  { id: 7, value: "Cacao" },
  { id: 8, value: "Picadillo" },
  { id: 9, value: "Pate" },
  { id: 10, value: "Caballa" },
  { id: 11, value: "Arroz" },
  { id: 12, value: "Arvejas" },
  { id: 13, value: "Sadinas" },
  { id: 14, value: "Atun" },
  { id: 15, value: "Choclo" },
  { id: 16, value: "Lentejas" },
];

export default function App() {

  const [textItem,setTextItem] = useState('')
  const [itemList,setItemList] = useState(productsExample)

   const handleChangeText = (text) => {
    console.log(text)
    setTextItem(text)
   }
   const addItem = () => {
    console.log ('add Item')
   }

  return (
    <ImageBackground
      source={require('./assets/ImgFondo.jpg')} // Ruta de la imagen
      style={styles.contenedor} // Estilo extraído al objeto styles
      resizeMode="cover" // Asegura que la imagen cubra todo el fondo
    >
      {/* Header con el texto en la parte superior */}
      <View style={styles.header}>
        <Text style={styles.titulo}>AQFIT</Text>
      </View>
      
      {/* TextInput con fondo transparente y texto blanco */}
      <TextInput value = {textItem}
      onChangeText={handleChangeText}
        style={styles.input}
        placeholder='Escribe algo en el input'
        placeholderTextColor='gray'
      />
      
      <Button
        title='Presiona aqui'
        onPress={(addItem)}
        color='white'
      />

<View>
    {itemList.map((item) => (
      <View key={item.id}>
        <Text>{item.value}</Text>
      </View>
    ))}
  </View>
</ImageBackground>

  );
}

const styles = StyleSheet.create({
  contenedor: {
    flex: 1,
    justifyContent: 'flex-start', // Esto asegura que los componentes estén alineados desde el principio
    alignItems: 'center',
    paddingVertical : 20,
  },
  header: {
    height: 80, // Espacio para el header
    backgroundColor: 'rgba(0, 0, 0, 0.5)', // Fondo transparente para el header
    width: '100%',
    justifyContent: 'center', // Centra el texto dentro del header verticalmente
    alignItems: 'center', // Centra el texto horizontalmente
  },
  titulo: {
    fontSize: 50,
    color: 'white',
  },
  input: {
    color: 'white',
    borderBottomWidth: 1,
    borderBottomColor: 'white',
    width: '80%',
    padding: 10,
    marginVertical: 10,
    backgroundColor: 'rgba(0, 0, 0, 0.5)', // Fondo transparente con algo de opacidad
  },
});
