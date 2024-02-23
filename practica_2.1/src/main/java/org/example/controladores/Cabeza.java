package org.example.controladores;



import org.example.entidades.Articulo;
import org.example.entidades.Comentario;
import org.example.entidades.Etiqueta;
import org.example.entidades.Usuario;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Optional;

public class Cabeza implements Serializable {
    private static final long serialVersionUID = 1L;
    private static List<Usuario> usuarios;
    private static List<Articulo> articulos;
    private static List<Comentario> comentarios;
    private static List<Etiqueta> etiquetas;
    private static Cabeza cabeza;

    private int id_articulo = 1;
    private int id_etiqueta = 10;
    private int id_usuario = 3;
    private int id_comentario = 0;

    public Cabeza() {
        this.usuarios = new ArrayList<>();
        this.articulos = new ArrayList<>();
        this.comentarios = new ArrayList<>();
        this.etiquetas = new ArrayList<>();
        this.usuarios.add(new Usuario("Admin","admin","admin1234",true,true));
        this.usuarios.add(new Usuario("zaloke","Moises","1234",false,true));
        this.usuarios.add(new Usuario("autor-1","jose","hola1234",false,true));
//        this.etiquetas.add(new Etiqueta("Historia"));
//        this.etiquetas.add(new Etiqueta("Comedia"));
//        this.etiquetas.add(new Etiqueta("Personal"));
        this.articulos.add(new Articulo("la historia de mi vida","contenido de la vida", find_usuario("autor-1"), new Date(),null,etiquetas));
        this.articulos.add(new Articulo("Usando Javalin","Esto es una prueba", find_usuario("zaloke"), new Date(),null,etiquetas));
    }

    public static Cabeza getInstance() {
        if (cabeza == null) {
            cabeza = new Cabeza();
        }
        return cabeza;
    }

    public static List<Usuario> getUsuarios() {
        return usuarios;
    }

    public static void setUsuarios(List<Usuario> usuarios) {
        Cabeza.usuarios = usuarios;
    }

    public static List<Articulo> getArticulos() {
        return articulos;
    }

    public static void setArticulos(List<Articulo> articulos) {
        Cabeza.articulos = articulos;
    }

    public static List<Comentario> getComentarios() {
        return comentarios;
    }

    public static void setComentarios(List<Comentario> comentarios) {
        Cabeza.comentarios = comentarios;
    }

    public static List<Etiqueta> getEtiquetas() {
        return etiquetas;
    }

    public static void setEtiquetas(List<Etiqueta> etiquetas) {
        Cabeza.etiquetas = etiquetas;
    }

    public void add_user(Usuario temp) {
        usuarios.add(temp);
    }



    public void add_etiqueta(String temp) {
        Etiqueta aux = new Etiqueta(temp);
        id_etiqueta++;
        aux.setId(id_etiqueta);
        etiquetas.add(aux);

    }

    public void add_comentario(Comentario temp) {
        id_comentario++;
        temp.setId(id_articulo);
        comentarios.add(temp);
    }

    public Usuario find_usuario(String username) {
        Usuario temp = null;
        Optional<Usuario> usuarioEncontrado = usuarios.stream()
                .filter(usuario -> username.equals(usuario.getUsername()))
                .findFirst();
        if (usuarioEncontrado.isPresent()) {
            Usuario usuario = usuarioEncontrado.get();
            // Realizar acciones con el usuario encontrado
            return usuario;
        } else {

            return null;
        }

    }
   //====================================================================
   public Articulo find_Articulo(Long id) {
       for (Articulo articulo : articulos) {
           if (articulo.getId() == id) {
               return articulo;
           }
       }
       return null; // Retorna null si no se encuentra ningún artículo con el ID proporcionado
   }

    public List<Articulo> listarArticulos(){
        return articulos;
    }

    public void add_articulo(Articulo temp) {
        temp.setId(id_articulo);
        id_articulo++;
        articulos.add(temp);
    }
    public void modArticulo(Articulo temp, long id){
        Articulo aux  = find_Articulo(id);
        aux.setTitulo(temp.getTitulo());
        aux.setCuerpo(temp.getCuerpo());
        aux.setFecha(temp.getFecha());
        aux.setListaEtiquetas(temp.getListaEtiquetas());
    }
    public void deleteArticulo(Long id) {
        for (int i = 0; i < articulos.size(); i++) {
            Articulo articulo = articulos.get(i);
            if (articulo.getId() == id) {
                articulos.remove(i); // Elimina el artículo de la lista
                i--; // Ajusta el índice después de la eliminación
            }
        }
    }

    //===================================================================
    public List<Etiqueta> listarEtiquetas(){
        return etiquetas;
    }
    public Comentario find_comentario (Long id){
        return comentarios.stream()
                .filter(comentario -> id.equals(comentario.getId()))
                .findFirst()
                .orElse(null);
    }

    public Etiqueta find_Etiqueta (String nametag){
        return etiquetas.stream()
                .filter(etiqueta -> nametag.equals(etiqueta.getEtiqueta()))
                .findFirst()
                .orElse(null);
    }



    public List<Usuario> listarUsuarios(){
        return usuarios;
    }



    public List<Comentario> listarComentarios(){
        return comentarios;
    }


    public boolean usuarioExiste(String username) {
        return usuarios.stream().anyMatch(usuario -> usuario.getUsername().equals(username));
    }

    public boolean validPassword(String password, Usuario user){
        if(user.getPassword().equals(password)){
            return true;
        }
        return false;
    }


}
