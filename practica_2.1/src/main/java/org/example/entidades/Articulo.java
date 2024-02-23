package org.example.entidades;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Articulo {
    private long id;
    private String titulo;
    private String cuerpo;
    private Usuario autor;
    private Date fecha;
    private List<Comentario> listaComentarios;
    private List<Etiqueta> listaEtiquetas;

    private int count = 0;


    // Constructores, getters y setters

    public Articulo( String titulo, String cuerpo, Usuario autor, Date fecha, List<Comentario> listaComentarios, List<Etiqueta> listaEtiquetas) {
        this.id = id;
        this.titulo = titulo;
        this.cuerpo = cuerpo;
        this.autor = autor;
        this.fecha = fecha;
        this.listaComentarios = new ArrayList<>();
        this.listaEtiquetas = new ArrayList<>();
    }

    public long getId() {
        return id;
    }

    public String getTitulo() {
        return titulo;
    }

    public String getCuerpo() {
        return cuerpo;
    }

    public Usuario getAutor() {
        return autor;
    }

    public Date getFecha() {
        return fecha;
    }

    public List<Comentario> getListaComentarios() {
        return listaComentarios;
    }

    public List<Etiqueta> getListaEtiquetas() {
        return listaEtiquetas;
    }

    public void setId(long id) {
        this.id = id;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public void setCuerpo(String cuerpo) {
        this.cuerpo = cuerpo;
    }

    public void setAutor(Usuario autor) {
        this.autor = autor;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public void setListaComentarios(List<Comentario> listaComentarios) {
        this.listaComentarios = listaComentarios;
    }

    public void setListaEtiquetas(List<Etiqueta> listaEtiquetas) {
        this.listaEtiquetas = listaEtiquetas;
    }

    public void add_comentario(Comentario temp){
        count++;
        temp.setId(count);
        listaComentarios.add(temp);
    }
    public void add_etiqueta(Etiqueta temp){
        listaEtiquetas.add(temp);
    }
}
