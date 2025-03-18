import { TextInput, Text, View, Button, ImageBackground, StyleSheet } from 'react-native';

export default function App() {
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
      <TextInput
        style={styles.input}
        placeholder='Escribe algo en el input'
        placeholderTextColor='gray'
      />
      
      <Button
        title='Presiona aqui'
        onPress={() => alert('Botón presionado')}
        color='white'
      />
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  contenedor: {
    flex: 1,
    justifyContent: 'flex-start', // Esto asegura que los componentes estén alineados desde el principio
    alignItems: 'center',
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
